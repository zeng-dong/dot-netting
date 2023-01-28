Manning 2022

### Blazor WebAssembly template configurations
You can configure VS Blazor WebAssembly template in two modes, 
- hosted (enable the ASP.NET Core Hosted option on creation)
	- three projects in the solution
	- a full-stack .NET application
- standalone (default).



# Building Blazing Trails

#### Program.cs
Blazor WebAssembly, runs a WebAssemblyHost

WebAssemblyHostBuilder needs two critical configurations: the root components; any services

Two root elements defined by the template: App, HeadOutlet

Same DI as other ASP.NET Core apps. 
- for Blazor WebAssembly, Scoped and Singleton behave the same. Because there is no request in a Blazor WebAssembly application.

WebAssemblyHost is the heart of your Blazor app. It contains all the application configurations and services needed to run your app.

#### defining layout
the default layout is defined within the Router component
the layout will automatically be applied to all pages in the application

alternatively, use the @layout directive
