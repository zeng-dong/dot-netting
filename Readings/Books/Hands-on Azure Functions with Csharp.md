#### Azure Functions Core Tools
- https://github.com/Azure/azure-Functions-core-tools
- I installed v4 from msi

##### create an Azure Function Project
func init --worker-runtime dotnet
or: func init, and it will prompt for runtime

##### create a Function inside the Azure Function Project
func Function new --template HttpTrigger –-name TestFunction

##### execute the Function 
func host start


#### Create Functions using visual studio
Azure Functions template
Functions worker: .NET 6.0
Function: Http trigger
checked: Use Azurite for runtime storage account (AzureWebJobsStorage)
Authorization level: anonymous
Run the function as normal project
	- it starts the storage emulator
	- it starts the function runtime
	- it hosts all the functions present inside the function app

