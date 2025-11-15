
# Docker for Software Development: SQL Server
https://github.com/FeynmanFan/sql-docker

# getting SQL Server up and running

docker pull mcr.microsoft.com/mssql/server:2022-latest
#### the run command
docker run --name testdb -d -p 1433:1433 -e "MSSQL_SA_PASSWORD=G52ndT0ur" -e "ACCEPT_EULA=Y" mcr.microsoft.com/mssql/server:2022-latest

then use sql server management studio 21
* server: .
* sql server auth
* sa
* G52ndT0ur
* check remember password
* check 'trust server certificate'
* connect
* is in, open a new query and 'select @@version'


# zd notes

when I try
```
docker pull mcr.microsoft.com/mssql/server:2022-latest
``` 

I get:
> failed to copy: httpReadSeeker: ...... EOF

with Docker Desktop so I shut it down and installed Rancher Desktop and run it.

Then Rancher Desktop diagnosis that Docker context is Docker-Desktop, not default Ubuntu. If I 'docker ps' I get some error. 
So I run command 
```
docker context use default
```

now 'docker ps' works and also I am able to 'docker pull mcr.microsoft.com/mssql/server:2022-latest'

### running Ardalis clean-arch templated solution
with Docker Desktop running, docker pull sql server fails, even with some latest versions (4.50 for example)
so I switch to Rancher Desktop and I have to run
```
docker context use default
```
now the Aspire dashboard sees resources are running, include Papercut and Sqlserver
use this conn string to connect with ssms
```
Server=127.0.0.1,57537;User ID=sa;Password=p_.G~W!)MdH98TCgQF~ujx;TrustServerCertificate=true
```

