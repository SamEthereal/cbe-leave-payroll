# Architecture Document

## Modular Monolith Design
The system is built as a **Single-Project Modular Monolith** inside `LeavePayroll.Web` in ASP.NET Core .NET 9 with server-side Blazor UI:

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
