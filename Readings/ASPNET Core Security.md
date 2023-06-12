
# HTTP headers
from Manning ASP.NET Core Security, chapter 9

* Understanding leaky ASP.NET Core HTTP response headers
* Removing HTTP headers that are too revealing
* Discovering HTTP headers offering browser security features
* Adding custom HTTP headers to an HTTP response

## Hiding server information
revealing or even offending header:
server
X-Powered-By

the UseKestrel() method of the IWebHostBuilder interface, which is usually available via the builder.WebHost property. The following code removes the Server HTTP header.

```c#
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(options =>
{
	options.AddServerHeader = false;
});
```
 
## Browser security headers
### Referrer
* contains the URL of the document that was loaded in the browser window or tab when the current HTTP request was made 
* The Referer header is sent automatically by web browsers, so it’s not an application feature
* To give developers control over when to send the header, and if so, whether to limit the information in it, Referrer Policy was created
* The central element of Referrer Policy is the Referrer-Policy HTTP header.

to use Referrer Policy from an ASP.NET Core application with kestrel
```c#
app.Use(async (context, next) => {
	context.Response.Headers.Add(             
        "Referrer-Policy", "no-referrer");
    await next.Invoke();
})

// or it is also possible to set the HTTP header in an individual page:
HttpContext.Response.Headers.Add("Referrer-Policy", "no-referrer");

```
and make sure that you are using this code snippet before any other middleware that might cause a redirect


# Andrew Lock nuget package
[github](https://github.com/andrewlock/NetEscapades.AspNetCore.SecurityHeaders)

[usage example](https://damienbod.com/2021/08/30/improving-application-security-in-an-asp-net-core-api-using-http-headers-part-3/)



# Pluralsight: Secure Coding with OWASP in ASP.NET Core 6
[code](https://github.com/gavin-jl-ps/Secure-Coding-with-OWASP-in-ASP.NET-Core-6)

### demo setup:
3.2
scaffolding on sqlite


# 12 Hardening Configuration

### Set HTTP Security Headers in Response

### hide system component
#### remove the server header
if you use IIS in web.config add 

```xml
<security>
	<requestFiltering removeServerHeader="true" />
</security>
```

if you use kestrel, you can configure that in your code
- ASP.NET Core project templates use Kestrel by default when not hosted with IIS. In `Program.cs`, the [WebApplication.CreateBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplication.createbuilder) method calls [UseKestrel](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderkestrelextensions.usekestrel) internally

```c#
builder.WebHost.ConfigureKestrel(serverOptions => {
	serverOptions.AddServerHeader = false;
})
```