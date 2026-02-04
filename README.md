# Event-Driven Tickets System (CQRS + Read Models)
The project demonstrates a clean, testable, and scalable backend architecture focused on business logic, aggregates, domain events, and projections. It does not include UI or complex infrastructure.

---

## Project Goal

This system implements a clear separation of write and read models, enforces business rules in the domain, and propagates state changes through domain events.  
It is fully testable, scalable, and designed to show how enterprise-grade architecture can be applied in backend systems. The focus is on correct handling of domain invariants, CQRS patterns, and eventual consistency.

---

## Domain Overview

The domain models a Ticket Management System. Each Ticket has a status which can be Draft, Submitted, Approved, or Rejected. All business rules are enforced in the Ticket aggregate, and each meaningful state change raises a domain event. Domain events are immutable records of actions that have occurred and are used to update other parts of the system, including read models.

### Core Entities

- `Ticket` – the aggregate root handling business rules and state transitions.
- `TicketStatus` – represents the current state of the Ticket.
- Domain Events – `TicketCreatedEvent`, `TicketSubmittedEvent`, `TicketApprovedEvent`, `TicketRejectedEvent`.

The domain layer does not contain persistence, repositories, or HTTP calls. Its sole responsibility is to enforce rules and emit events.

---

## Application Layer

The application layer coordinates domain logic and infrastructure. It contains commands, command handlers, repository interfaces, and UnitOfWork. Handlers are responsible for:

- Loading aggregates from repositories.
- Invoking domain operations.
- Persisting changes via UnitOfWork.
- Dispatching domain events to projections or other handlers.

Implemented commands:

- `CreateTicketCommand` – creates a new ticket and raises `TicketCreatedEvent`.
- `SubmitTicketCommand` – submits a draft ticket and raises `TicketSubmittedEvent`.
- `ApproveTicketCommand` – approves a submitted ticket and raises `TicketApprovedEvent`.
- `RejectTicketCommand` – rejects a submitted ticket with a reason and raises `TicketRejectedEvent`.

Command handlers are fully tested using fakes for repositories and UnitOfWork. Custom exceptions such as `TicketNotFoundException` ensure meaningful error handling.

---

## Read Model

The read side contains denormalized models optimized for queries. Ticket projections update read models in response to domain events. The read model layer contains:

- `TicketReadModel` – stores ticket data for queries.
- Projection handlers – handle domain events and update read models.
- Interfaces – `ITicketReadRepository` abstracts persistence for read models.

The read model is fully separated from the domain and does not contain business rules.

---

## Infrastructure Layer

This layer provides repository and UnitOfWork implementations. Responsibilities include:

- Persisting aggregates to the database.
- Handling transactional consistency.
- Storing domain events for dispatching.

The infrastructure layer currently supports synchronous in-memory event dispatching, but is designed to allow future implementation of the outbox pattern or background workers for asynchronous event processing.

---

## Event Flow

The flow of actions in the system:

1. A command is sent to an application handler.
2. The handler loads the aggregate from a repository.
3. Domain methods are invoked, changing state and raising events.
4. The UnitOfWork commits changes to the database.
5. Domain events are dispatched to read model projections.

This ensures that the write side enforces rules and the read side eventually reflects the current state.

---

## Testing Strategy

Testing focuses on ensuring correctness of domain logic and application coordination.

---

This project demonstrates aggregate-centered design, strict enforcement of domain rules, explicit transaction boundaries via UnitOfWork, event-driven read models, and separation of concerns for a clean, maintainable backend architecture.
