# Expense Tracker API

A backend-focused ASP.NET Core Web API for tracking personal expenses across multiple accounts.  
This project is designed to demonstrate clean domain modelling, RESTful API design, and modern .NET backend development practices.

## Overview

The Expense Tracker API allows users to record and manage financial transactions associated with different accounts, such as cash, debit, or credit accounts. The application is intentionally API-only and uses Swagger UI as the primary interface for exploring and testing endpoints during development.

The project prioritises clarity, correctness, and maintainability over feature completeness, with a focus on real-world backend concerns such as data ownership, persistence, and authentication.

## Domain Model

The core domain concepts are:

### User
Represents a person who uses the system to manage and track their expenses.

### Account
Represents a source of funds belonging to a user, such as a cash wallet, debit account, or credit account.

### Transaction
Represents a financial event where money is spent or received from an account.

Ownership is modelled as:

User > Account > Transaction

A user owns their accounts, and each transaction belongs to a single account.  
Users must never be able to view or modify accounts or transactions belonging to other users.

## Technology Stack

### Current
- .NET 10 (LTS)
- ASP.NET Core Web API
- C#
- Swagger / OpenAPI (Swashbuckle)

### Planned additions
- PostgreSQL database
- Entity Framework Core
- JWT-based authentication and authorization

## API Interface

Swagger UI is used as the primary interface for exploring and testing the API during development. It provides a self-documenting, interactive way to inspect endpoints, request models, and responses.

Once the application is running, the Swagger UI is available at:

`/swagger`

## Authentication

Authentication will be implemented using JSON Web Tokens (JWT). This ensures that:

- Users can securely authenticate with the API
- Requests are authorised based on user identity
- Data access is scoped to the authenticated user

Authentication concerns are intentionally kept separate from the core domain models.

## Project Status

This project is under active development. Planned next steps include:

- PostgreSQL persistence via Entity Framework Core
- Explicit foreign key relationships and database migrations
- JWT authentication and authorization
- Validation and error handling
- RESTful API endpoint implementation

## Design Notes

- The project is intentionally backend-only; no frontend UI is included.
- Domain entities are kept free of authentication and security concerns.
- Sensitive data such as passwords or payment card details is deliberately excluded.
- The design favours clear ownership, explicit relationships, and predictable behaviour.

## Getting Started

1. Clone the repository
2. Run the project using the .NET CLI or your preferred IDE
3. Open the Swagger UI to explore available endpoints