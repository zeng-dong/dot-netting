# Mark Heath: MS Azure Developer: Implement Azure Functions

#### create a function app
- I log in to Protective portal
- switch to my AD
- create rg zd-az-functions
- create a function app: zd-first-functionapp
	- node.js
	- consumption
	- windows
	- enable appInsight
	- storage account: zdazfunctionsb87e


## triggers
### objective
implement function triggers by using data operations, timers, and webhooks


http request trigger: webhooks
Timer Trigger: scheduled task 
Blob Storage Trigger: data operation
Queue trigger
cosmos db trigger: a ducument is created or updated
blob trigger: a new file is uploaded to blob storage

### HTTP Request Trigger
methods
route
secured via authorization key
	- anonymous: no key required
	- function: key per function
	- admin: key per function app
#### create a function with http request trigger
In the above function app 'zd-first-functionapp'
1. select Functions
2. click Add
3. select the Http Trigger template
4. accept default (name HttpTrigger1, security: Function)
5. once created, go to "Code + Test"
6. click "Test/Run" -> Run
7. should get 200 OK
8. click "Get function URL"
9. like this: https://zd-first-functionapp.azurewebsites.net/api/HttpTrigger1?code=GIrZZ-9SSlhBLvAZnXQO0lCXFm-lKTdcb-UnpLClKCVpAzFukOHL3g==
10. I can call the function in a browser like this: https://zd-first-functionapp.azurewebsites.net/api/HttpTrigger1?code=GIrZZ-9SSlhBLvAZnXQO0lCXFm-lKTdcb-UnpLClKCVpAzFukOHL3g==&&name=hithere

### Timer trigger
CRON expression
	- determines when your function should run
#### create a function with timer trigger
In the above function app 'zd-first-functionapp'
1. select Functions
2. click Add
3. select the Timer Trigger template
4. accept the defualt name TimerTrigger1 and Schedule (0*/%**** - means to run every 5 minutes)
5. navigate to the code
6. view the log after 5 minutes
7. I can disable/delete the function to avoid it running.
8. I just disabled it.


# Mark Heath: Azure Durable Functions Fundamentals
- an extension to Azure Functions
- write "stateful" functions in a "serverless" environment
- define workflows in code
- FaaS
- 




# Apress Hands-on Azure Functions with Csharp

#### Azure Functions Core Tools
- https://github.com/Azure/azure-Functions-core-tools
- I installed v4 from msi

##### create an Azure Function Project
func init --worker-runtime dotnet
or: func init, and it will prompt for runtime




