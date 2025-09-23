# RefactorToNewCSharp

A demonstration of modern C# features and best practices, refactoring legacy C# code to leverage C# 12/13 improvements like **primary constructors**, **records**, **pattern matching**, and **EF Core interceptors**.

---

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

---

## Description

This project showcases a small shop application refactored to use modern C# syntax and EF Core features. It emphasizes code readability, maintainability, and best practices for building scalable .NET applications.

---

## Features

- **C# 12/13 Features**:
  - Primary constructors
  - Records for DTOs
  - Pattern matching with relational patterns
- **Entity Framework Core**:
  - Shadow properties (`CreatedAt`, `CreatedBy`)
  - SaveChanges interceptor for logging
  - In-memory database setup for demonstration
- **Async/Await Support**: All database operations have async implementations.
- **Clean Architecture**: Separation of models, DTOs, services, and data access layers.

---

## Installation

Clone the repository:

```bash
git clone https://github.com/nikravesh/RefactorToNewCSharp.git
```

Navigate to the project folder:

```bash
cd RefactorToNewCSharp
```

Open the solution in Visual Studio 2022 (or later) or your preferred IDE and build the solution to restore NuGet packages.

---

## Usage

Run the application to see the refactored shop project in action. Example usage is in `Program.cs`:

```csharp
Product laptop = new("Laptop", 10000);
Product book = new("Book", 100);

ProductService productService = new(new ShopDbContext());
await productService.AddProductAsync(book);
await productService.AddProductAsync(laptop);
await productService.SaveAsync();

productService.CategorizeProduct(book);
productService.CategorizeProduct(laptop);

var productDto = await productService.GetProductAsync(1);
Console.WriteLine($"{productDto.Name} costs {productDto.Price}");
```

This demonstrates adding products asynchronously, saving changes to the in-memory database, categorizing products based on price, and retrieving products using DTOs.

---

## Contributing

Contributions are welcome! Fork the repository, create a new branch for your feature or bugfix, commit your changes with clear messages, and open a pull request. Ensure your code follows C# coding standards and includes proper testing.

---



## Optional Enhancements

You can add badges for build status or test coverage, include screenshots or GIFs to demonstrate functionality, and expand the Usage section with more examples.

