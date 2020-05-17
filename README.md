# NetCoreApis-Mssql-Docker
NetCoreApis-Mssql

# Pull Images
- Docker pull mcr.microsoft.com/mssql/server:2017-CU14-ubuntu Docker pull mcr.microsoft.com/dotnet/core/sdk:3.0
- Docker pull mcr.microsoft.com/dotnet/core/aspnet:3.0
- Docker pull nginx:stable-alpine
- Docker pull node:12.8-alpine

# SQL server linux on docker
- docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1112:1433 -d --name mydatabase mcr.microsoft.com/mssql/server:2017-CU14-ubuntu
- docker start <container id or container name>

# Scaffold Mssql
- dotnet ef dbcontext scaffold 'Server=localhost,1112;user id=sa; password=Password!; Database=Northwind' Microsoft.EntityFrameworkCore.SqlServer -o DbModels -c DatabaseContext --context-dir Database