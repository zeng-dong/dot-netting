## timeline
#### 2023.04.09
start the solution


### commands
dotnet new -l

### steps
mkdir Reactivities
cd
dotnet new sln
dotnet new webapi -n API
dotnet new classlib -n Application
dotnet new classlib -n Domain
dotnet new classlib -n Persistence
dotnet sln add API/API.csproj
dotnet sln add Application
dotnet sln add Domain
dotnet sln add Persistence
dotnet sln list
cd API
dotnet add reference ../Application
cd ..
cd Application
dotnet add reference ../Persistence
dotnet add reference ../Domain
cd ..
cd Persistence
dotnet add reference ../Domain


