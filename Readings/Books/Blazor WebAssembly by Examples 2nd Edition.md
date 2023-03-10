2023
Packt
.NET 7

source code: https://github.com/PacktPublishing/Blazor-WebAssembly-by-Example-Second-Edition
color images: https://packt.link/Q27px

# 1. Introduction to Blazor WebAssembly
3 different hosting models
goals of WebAssembly

- SPA framework
When a page is rendered, Blazor creates a render tree that is a graph of the components on the page. It is like the Document Object Model (DOM) created by the browser. However, it is a virtual DOM.

- Razor syntax
Razor components. 
    Unlike Razor Pages and MVC, which renders the whole page, Razor components only render the DOM changes
    .razor vs .cshtml

## hosting models
Razor components are hosted varies depending on the hosting model.
### Blazor Server
the Razor components are executed on the server
### Blazor Hybrid
allows you to build native client apps by hosting the components in an embedded Web View control
### Blazor WebAssembly
the Razor components are executed on the browser using WebAssembly

The major differences between the hosting models concern where the code executes, latency, security, payload size, and offline support. 
The one thing that all the hosting models have in common is the ability to execute at near native speed.