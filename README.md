** WORK IN PROGRESS ** 

# 🧠 Event‑Driven Tickets System (CQRS + Read Models + Outbox)

A backend‑only, enterprise‑style system built with **Event‑Driven Architecture**, **CQRS**, **Domain‑Driven Design**, and **Read Models**.  
The goal of this project is to demonstrate a clean, testable, scalable architecture used in real production systems.

---

## 🎯 Project Goal

> A backend system based on Event‑Driven Architecture and CQRS, separating Write and Read models, ensuring fault tolerance, eventual consistency, and a fully testable domain layer.

This project intentionally focuses on **architecture**, not UI or infrastructure complexity.

---

## 🏗️ Domain Overview

The domain represents a **Ticket / Request Management System** — simple enough to implement, but rich in rules and events.

### Core Entities

- `Ticket`
- `Comment`
- `User` (backend‑only)
- `TicketStatus`  
  - Draft  
  - Submitted  
  - Approved  
  - Rejected

Why this domain?

- realistic business rules  
- natural event flow  
- easy to extend  
- perfect for CQRS + EDA  

---

## 📁 Solution Structure

```
EventDrivenTickets.sln
│
├── src
│   ├── Tickets.API
│   ├── Tickets.Application
│   ├── Tickets.Domain
│   ├── Tickets.Infrastructure
│   └── Tickets.ReadModel
│
└── tests
    ├── Tickets.Domain.Tests
    └── Tickets.Application.Tests
```

---

## 🧩 Layer Responsibilities

### 🟡 Domain Layer (`Tickets.Domain`)

**No EF Core. No HTTP. Pure business logic.**

Contains:

- Entities & Aggregates
- Value Objects
- Domain Events
- Business Rules

Example events:

```csharp
TicketSubmittedEvent
TicketApprovedEvent
TicketRejectedEvent
```

This is the **heart of the system**.

---

### 🔵 Application Layer (`Tickets.Application`)

Implements CQRS using:

- Commands
- Queries
- Command Handlers
- Event Handlers
- Interfaces (Repository, Unit of Work)

Examples:

```csharp
SubmitTicketCommand
ApproveTicketCommand
GetTicketDetailsQuery
```

Technologies:

- MediatR  
- FluentValidation  
- CQRS pattern  

---

### 🟢 Infrastructure Layer (`Tickets.Infrastructure`)

Responsible for:

- EF Core persistence
- Repositories
- Unit of Work
- Outbox table
- Background worker for event dispatching

This layer **stores domain events** and ensures reliable processing.

---

### 🟣 Read Model (`Tickets.ReadModel`)

A separate schema/database optimized for queries.

- Dapper
- Projection Handlers
- Denormalized read models

Examples:

```csharp
TicketListReadModel
TicketDetailsReadModel
```

This separation dramatically improves performance and scalability.

---

### 🔴 API Layer (`Tickets.API`)

- Controllers
- Simple authentication (fake JWT)
- Swagger documentation

---

## 🔄 Event Flow

```
HTTP Request
  ↓
Command
  ↓
Domain Entity
  ↓
Domain Event
  ↓
Outbox Table
  ↓
Background Worker
  ↓
Read Model Projection
```

This is the **core enterprise pattern**: reliable event processing + eventual consistency.

---

## 🧠 CQRS Done Right

### WRITE Model

- EF Core
- Transactions
- Validation
- Domain Events

### READ Model

- Dapper
- Denormalized tables
- Pagination & filtering
- No EF Core ❌

---

## 🧪 Testing Strategy

Not 100% coverage — **smart coverage**.

Focus on:

- Domain rules
- Command handlers
- Event handlers

Example domain tests:

```
TicketTests
- cannot approve draft ticket
- cannot submit without title
```

---

## 📦 Outbox Pattern (Advanced)

Outbox table:

```sql
OutboxMessages
- Id
- Type
- Payload
- ProcessedAt
```

Background worker:

- fetches unprocessed events  
- publishes them to handlers  
- retries failed events  
- moves dead events to dead‑letter storage  

---

## 📘 README Must‑Have Sections

This repository includes:

1. Architecture overview  
2. Event flow explanation  
3. CQRS design  
4. Read model design  
5. Trade‑offs & limitations  
6. Future improvements  

---

## 🚀 Development Roadmap

### 1️⃣ Domain

- Ticket aggregate  
- Status transitions  
- Domain events  

### 2️⃣ Commands

- Create  
- Submit  
- Approve / Reject  

### 3️⃣ Outbox

- event persistence  
- background worker  

### 4️⃣ Read Model

- ticket list  
- ticket details  

### 5️⃣ Tests

- domain first  
- application next 
