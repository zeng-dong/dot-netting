# Pluralsight: Secure Coding with OWASP in ASP.NET Core 6
[code](https://github.com/gavin-jl-ps/Secure-Coding-with-OWASP-in-ASP.NET-Core-6)

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

```c#
builder.WebHost.ConfigureKestrel(serverOptions => {
	serverOptions.AddServerHeader = false;
})
```