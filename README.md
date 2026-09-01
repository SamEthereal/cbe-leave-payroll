# Leave & Payroll Management System

Modular Monolith ASP.NET Core (.NET 9) application with EF Core, SQL Server, and Blazor Web App UI for Commercial Bank of Ethiopia (CBE Djibouti & CBE South Sudan).

## Structure
```
LeavePayroll/
├── src/
│   └── LeavePayroll.Web/
│       ├── Components/
│       ├── Domain/
│       ├── Application/
│       ├── Infrastructure/
│       └── wwwroot/
├── tests/
│   ├── Domain.Tests/
│   ├── Application.Tests/
│   └── Integration.Tests/
├── docs/
└── README.md
```

## How to Run
```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/LeavePayroll.Web/LeavePayroll.Web.csproj
```
