
## strict mode

## modern build tooling with vite
if using 17+ and is still using webpack, use this command to upgrade to vite:
```cmd
ng update @angular/cli --name use-application-builder
```
previously in devDependencies it is the wrapper on webpack:
@angular-devkit/build-angular

## use signals for simplified reactivity

simpler and more predictable way to manage reactivity
compared to relying solely on RXJS or the automatic change detection powered by Zone JS. 

Signals should generally be the default choice when 
	looking for ways to manage component state, 
	handle inputs and outputs, and 
	keep templates reactive without extra complexity
	
 While RXJS remains the right choice for 
	 complex asynchronous streams, 
	 event-driven workflows, or 
	 reactive transformations, 
	 
generally speaking, signals should be your go to for local, state, general state management, and straightforward reactivity



<table border="0">
 <tr>
    <td><b style="font-size:30px">Title</b></td>
    <td><b style="font-size:30px">Title 2</b></td>
 </tr>
 <tr>
    <td>Lorem ipsum ...</td>
    <td>Lorem ipsum ...</td>
 </tr>
</table>
