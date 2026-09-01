# Deployment Guide

## Prerequisites
- .NET 9 SDK
- SQL Server (or EF Core In-Memory for dev)

## Steps
1. Publish `LeavePayroll.Web`:
```bash
dotnet publish src/LeavePayroll.Web/LeavePayroll.Web.csproj -c Release -o ./publish
```
2. Configure database connection string in `appsettings.json`.
3. Run database migrations / seed data.
