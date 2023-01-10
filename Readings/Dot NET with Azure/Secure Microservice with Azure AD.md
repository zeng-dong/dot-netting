AAD is an Idnetity-as-a-Service (iDaaS) offering

Use AAD to configure your app's authentication and authorization.

# Introduction to AAD
- iDaas
- Completely managed by the underlying Azure platform
- Register you app
	- then you can create users who can use your app

## steps to configure your microservice for AAD based authentication
1. Register an application with Azure AD.
2. Create scopes for the application created in Azure AD to perform authorization.
3. Create a secret for your registered application.
4. Configure your microservices-based application with an AAD application ID, secret, and tenant ID.
### registration

### create the app Scope
we use the scope for the registered app to restrict access to the app
Expose an API -> Add a scope

### create the app secret
we use the secret for the app to access the app from the client
Certificates & secrets -> New client secret