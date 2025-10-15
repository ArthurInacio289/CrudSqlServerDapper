# CrudSqlServerDapper
# CrudSqlServerDapper

A sample CRUD application using **SQL Server** and **Dapper** in C#.  
This project demonstrates how to implement Create, Read, Update, and Delete operations against a SQL Server database using Dapper as a micro‑ORM.

---

## Table of Contents

- [Features](#features)  
- [Architecture / Project Structure](#architecture--project-structure)  
- [Prerequisites](#prerequisites)  
- [Getting Started](#getting-started)  
- [Configuration](#configuration)  
- [Usage](#usage)  
- [Project Status](#project-status)  
- [Contributing](#contributing)  
- [License](#license)  

---

## Features

- Basic CRUD operations (Create, Read, Update, Delete)  
- SQL Server as the backend database  
- Dapper for lightweight object mapping  
- Layered architecture (e.g., Data Access, Domain, etc.)  

---

## Architecture / Project Structure

Below is a rough outline of how the solution is organized:

```
CrudSqlServerDapper.sln
|
├── DataAccess        # Repository / database layer (Dapper queries)
├── Domain            # Entities / business models
├── WebApi / UI       # Presentation / API layer (if applicable)
└── (Other Layers)    # Services, DTOs, etc.
```

Each layer should have a specific responsibility (e.g. DataAccess handles all Dapper queries and connections).

---

## Prerequisites

Before you run this project, ensure you have:

1. **.NET SDK** installed (e.g. .NET 6 / .NET 7)  
2. **SQL Server** running (local, Docker, or remote)  
3. A database created for this project  
4. (Optional) A tool like **SQL Server Management Studio (SSMS)** or **Azure Data Studio** to manage the database  

---

## Getting Started

1. **Clone the repository**  
   ```bash
   git clone https://github.com/ArthurInacio289/CrudSqlServerDapper.git
   cd CrudSqlServerDapper
   ```

2. **Open in your IDE**  
   Use Visual Studio, VS Code, Rider, etc., and open `CrudSqlServerDapper.sln`.

3. **Restore dependencies**  
   ```bash
   dotnet restore
   ```

4. **Set up the database**  
   - Create a database in your SQL Server instance (e.g. `CrudDb`)  
   - Create the necessary tables / schema  
   - (Optional) Insert sample data

5. **Update connection string**  
   In your configuration file (e.g. `appsettings.json`, or `appsettings.Development.json`), set the connection string to point to your SQL Server and database.  
   Example:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=CrudDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
   }
   ```

6. **Build and run**  
   ```bash
   dotnet build
   dotnet run --project <YourStartupProject>
   ```
   Or start via your IDE.

---

## Configuration

| Key | Purpose |
|-----|---------|
| `ConnectionStrings:DefaultConnection` | The SQL Server connection string the application uses |
| (Other settings) | Describe any other configuration keys (e.g. logging, timeouts, etc.) |

Be sure **never** to commit sensitive credentials (e.g. production usernames or passwords). Use environment variables or secret storage in real projects.

---

## Usage

Once running, depending on how your app is built (API, console, UI), you can:

- **Create** new records  
- **Read** records (by id or list)  
- **Update** existing records  
- **Delete** records  

If this is a Web API, test endpoints via tools such as Postman, cURL, or Swagger UI.

Example (pseudo‑endpoints):

```text
GET  /api/items
GET  /api/items/{id}
POST /api/items
PUT  /api/items/{id}
DELETE /api/items/{id}
```

---

## Project Status

This repository is marked **WIP (Work in Progress)**.  
Expect changes, refactors, and new features. Use this as a learning / demonstration project rather than production‑ready code.

---

## Contributing

Contributions, issues, and feature requests are welcome!

1. Fork the repository  
2. Create a new branch (`git checkout -b feature/my-feature`)  
3. Make your changes / improvements  
4. Commit your changes (`git commit -m 'Add feature X'`)  
5. Push to the branch (`git push origin feature/my-feature`)  
6. Open a Pull Request  

Please follow any existing coding standards / conventions in the project.

---

## License

Specify here your license (MIT, Apache 2.0, etc.).  
If you haven’t chosen one yet, you can add a `LICENSE` file and reference it here.

---

## Acknowledgements / References

- Dapper documentation  
- Tutorials and blog posts used as reference  
- SqlServer / .NET community resources  
