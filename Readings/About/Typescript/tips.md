
# using ts-node in my typescript design patterns project
I get this error when I try to run 
```cmd
ts-node .\nested-subscriptions.ts
```
(node:11984) Warning: To load an ES module, set "type": "module" in the package

I open the package.json and added this line
```
"type": module
```

like this:
```
{
    "name": "typescript-designpatterns-rxjs",
    "version": "1.0.0",
    "description": "",
    "type": "module",
    "main": "module",
```

and now it works.


# running unit tests via jest in my ypescript design patterns project
```
// run all
npm test

// run single one
npm test -t src/tryouts/testable-function.spec.js
```

# init a typescript project
## For example, following this PL course: Using Arrays and Collections in Typescript 5
1. npm init
2. npm install -g typescript
3. tsc --init --outDir jsFiles --rootDir tsFiles --sourceMap                   // this will create the  tsconfig.json

## another example, following this PL course: TypeScript 4 In-Depth
To install typescript the most popular way is using npm
* npm install -g typescript
* tsc --version
* tsc -v
### using vs code for ts
1. create a folder
2. manually add a tsconfig.json
```
	{
		"compilerOptions": {
			"target": "es6",
			"outDir": "js",
			"watch": true
		}
	}
```
3. now issue tsc
