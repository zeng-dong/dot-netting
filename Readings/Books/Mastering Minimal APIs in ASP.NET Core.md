Packt
2022

# chapter 2 Exploring minimal APIs and their advantages
## Routing
*Routing is responsible for matching incoming HTTP requests and dispatching those requests to the app’s executable endpoints. Endpoints are the app’s units of executable request-handling code. Endpoints are defined in the app and configured when the app starts. The endpoint matching process can extract values from the request’s URL and provide those values for request processing. Using endpoint information from the app, routing is also able to generate URLs that map to endpoints.*
-Microsoft

- used to be: UseEndpoints() or attribute routeing: Route, HttpGet, HttpPost
- Map*() of the WebApplication object
	- as soon as we add an endpoint to our application (for example, MapGet())
		- UseRouting() is automatically added at the start of the middleware pipeline
		- and UseEndpoints() is automatically added at the end of the middleware pipeline
- use MapMethods for specific methods(patch, head, options): app.MapMethods("/update-order", new[] { HttpMethods.Patch}, () => {  // updating })	

### route handler
### route parameters
If the route values cannot be casted to the specified types, then an exception of the **BadHttpRequestException** type will be thrown, and the API will respond with a **400 Bad Request** message.
### route constraints
If, according to the constraints, no route matches the specified path, we don’t get an exception. Instead we obtain a **404 Not Found** message,
### parameter binding
- route values
- query strings
- headers
- the body (as json, the only format supported by default)
- a service provider (dependency injection)

## Parameter binding
## Exploring responses
## Controlling serialization
## Architecting a minimal API project