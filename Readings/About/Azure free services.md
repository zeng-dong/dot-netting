
# sql database

1. create resource group: (New) zd-free-sqldatabase-rg
2. database name: zd-sql-db

Create SQL Database Server: zdsqlserver  (.database.windows.net)
Central US

Use both SQL and Micorsoft Entra authentication

## Networking
connectivity method:

I select Public endpoint
I Allow Azure services and resources t oaccess this server
I Add current client IP address

I use default TLS 1.2


Default collation
I use Sample Database (AdventureWorksLT)


## review
Authentication method: SQL and Microsoft Entra authentication
