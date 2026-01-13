# Product Listing Application

Product Listing Application is a backend-focused project built with **ASP.NET Core (.NET 10)** that serves product data from a JSON source and dynamically calculates product prices based on gold prices.

The project was initially implemented as a simple API and later **fully refactored** to follow **Clean Architecture principles**, with a strong focus on clean code, maintainability, and separation of concerns.

---

## Short Summary

This project focuses primarily on backend architecture and refactoring practices rather than frontend implementation. It is designed to demonstrate clean backend design, service separation, and modern ASP.NET Core development practices.

## Architecture Overview

The project follows a layered architecture:

- **Domain Layer**
  - Core business models such as `Product` and `ProductImages`
- **Application Layer**
  - Business logic and service abstractions
  - `ProductService` for product orchestration
  - `PricingService` for price calculation and gold price retrieval
- **API Layer**
  - Thin RESTful controllers
  - No business logic inside controllers
  - Swagger-documented endpoints

All dependencies are injected using **constructor-based Dependency Injection**, ensuring loose coupling and adherence to **SOLID principles**.

---

## Refactoring Summary

This project was refactored to improve overall code quality and architecture:

- Business logic was removed from controllers
- Service interfaces (`IProductService`, `IPricingService`) were introduced
- Pricing logic was separated into a dedicated service
- Hard-coded file paths were removed using `IWebHostEnvironment`
- Async I/O patterns were applied for scalability
- The codebase was prepared for future extensions such as filtering, caching, and external API integrations

The refactor transformed the project from a tightly coupled structure into a **clean, modular, and extensible backend system**.

---

## Features

- RESTful API serving product data from a JSON file
- Dynamic price calculation using the formula:
- Price = (popularityScore + 1) * weight * goldPrice


- Mocked gold price service (ready for real API integration)
- Swagger / OpenAPI documentation
- Clean separation of concerns
- Async-first design

---

## Tech Stack

- ASP.NET Core (.NET 10)
- C#
- Swagger / OpenAPI
- Newtonsoft.Json
- Dependency Injection
- Clean Architecture principles

---

## Running the Project

1. Clone the repository
2. Open the solution in Visual Studio
3. Run the API using HTTPS
4. Navigate to `/swagger` to explore the endpoints

---

## Future Improvements

- Real-time gold price integration via an external API
- DTO layer for API contracts
- Product filtering (price range, popularity score)
- Caching (Redis or in-memory)
- Unit and integration tests





