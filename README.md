# Expense Tracker API

A backend-focused ASP.NET Core Web API for tracking personal expenses across multiple accounts.
This project is designed to demonstrate clean domain modelling, RESTful API design, and modern .NET backend development practices using the .NET ecosystem.

## Overview

The Expense Tracker API allows users to manage accounts and record financial transactions associated with those accounts, such as cash, debit, or credit balances.

The application is intentionally API-only and uses Swagger UI as the primary interface for exploring and testing endpoints during development. The focus of the project is correctness, clarity, and maintainability rather than feature completeness.

The project models real-world backend concerns such as ownership, persistence, data boundaries, and API design.

## Domain Model

The core domain concepts are:

### User
Represents a person who uses the system to manage and track their expenses.

### Account
Represents a source of funds belonging to a user, such as a cash wallet, debit account, or credit account.

### Transaction
Represents a financial event where money is spent or received from an account.

Ownership is modelled as:

User → Account → Transaction

A user owns their accounts, and each transaction belongs to a single account.  
Users must never be able to view or modify accounts or transactions belonging to other users.

## Technology Stack

### Current
* .NET 10 (LTS)
* ASP.NET Core Web API
* C#
* Swagger / OpenAPI (Swashbuckle)
* PostgreSQL / EF Core

### Planned additions
* JWT-based authentication and authorization
* User-scoped data access enforcement
* Validation and structured error handling
* Pagination and filtering for collection endpoints
* Additional transaction-related endpoints

## Persistence

The application uses PostgreSQL as its backing store, with Entity Framework Core handling:
* Schema definition and migrations 
* Foreign key relationships
* Change tracking and persistence
* Query composition

Explicit foreign keys are used to enforce ownership boundaries between users, accounts, and transactions.

## API Interface

Swagger UI is used as the primary interface for exploring and testing the API during development. It provides a self-documenting, interactive way to inspect endpoints, request models, and responses.

Once the application is running, the Swagger UI is available at:

`/swagger`

## Authentication

Authentication will be implemented using JSON Web Tokens (JWT). This ensures that:

* Users can securely authenticate with the API
* Requests are authorised based on user identity
* Data access is scoped to the authenticated user

Authentication concerns are intentionally kept separate from the core domain models.

## Project Status

This project is under active development. Planned next steps include:

* JWT authentication and authorization
* Validation and error handling

## Design Notes

- The project is intentionally backend-only; no frontend UI is included.
- Domain entities are kept free of authentication and security concerns.
- Sensitive data such as passwords or payment card details is deliberately excluded.
- The design favours clear ownership, explicit relationships, and predictable behaviour.

## Getting Started

1. Clone the repository
2. Ensure PostgreSQL is running and configured
3. Apply database migrations
4. Run the project using the .NET CLI or your preferred IDE
5. Open the Swagger UI to explore available endpoints