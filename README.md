# Inventory Management System
Setup Instructions

Installation
1. Clone the repository:

2. Open the solution in Visual Studio:
  'Inventory'

3. Set Inventory.API as the startup project.

4. Apply the database migrations: 
   'update-database'


5. Run the project.

Endpoints:
. GET - /api/products
  Get a list of all products.

. GET - /api/products/{id}
  Get a product by id.

. POST - /api/products
  Create a new product.

. PUT - /api/products/{id}
  Update an existing product.

. DELETE - /api/products/{id}
  Delete a product by ID.


 Design Decisions
Layered Architecture: The solution is split into 4 projects:
  . Inventory.API: Hosts the controllers and endpoints.
  . Inventory.Application: Contains business logic and service interfaces.
  . Inventory.Infrastructure: Handles data access using Entity Framework Core.
  . Inventory.Tests: Contains unit tests.

Entity Framework Core is used for database operations with code-first migrations.

Dependency Injection is used to loosely couple services and repositories.

Unit Testing is included to ensure business logic correctness and reliability.

