
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


# monorepo
1. create a single workspace without any angular projects: ng new angular-patterns-monorepo --no-create-application
2. cd into the workspace
3. generate individual application project: 
	1. ng generate application shop
	2. ng generate application account
	3. ng generate application admin
4. generate other types of project:
	1. ng generate library my-shared-lib


