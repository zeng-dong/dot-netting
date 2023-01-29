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
