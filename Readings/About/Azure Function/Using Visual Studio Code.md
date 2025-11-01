
### set up
1. empty folder
2. terminal
3. check .net sdk: dotnet --version
4. check azure function core tools installed: func verstion
5. from extensions check "Azure Functions" extension installed
6. from extensions, to see, it is nice to see, "C# Dev Kit" extension installed

### create new project
1. navigate to the Azure tab in VSC
2. Workspace: Create Function...,  Create New Project...
3. but we can also use prompt: F1 => Function: new can see the list of command
4. run the Create new project command, it will some options: folder, language, .net runtime, trigger
5. we can 'skip for now' when select trigger
6. once done we get an empty function app, no functions in it yet

### create a http trigger function
* from command palllete: create function
* function name, namespace, access right (function, anonymous, admin)

#### test http triggered function locally
* f5
* 



## http triggers

### considerations
1. configure CORS
2. consider the impact of "cold start"
	1. "pre-warmed" instances
### capabilities
* customize the route
	* /api/funcName
	* /products/{category:alpha}/{id:int?}
* customize the http methods
* access incoming http request information
* key-based authorization system
* 

add to .gitignor:
__blobstorage__/
__queuestorage__/
__azurite_db.*.json
