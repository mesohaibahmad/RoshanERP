EF Migrations placeholder.
Run the following commands to create migrations and update DB:
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add Init
dotnet ef database update
