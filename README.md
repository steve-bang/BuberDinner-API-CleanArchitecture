# Buber Dinner

The model following Clean Architecture

```mermaid
flowchart TD
A[Bubber.Api] --> B[Bubber.Application]
E[Bubber.Infrastructure] --> B[Bubber.Application]
B[Bubber.Application] --> F[Bubber.Domain]
G[Bubber.Contracts] --> A[Bubber.Api]
```