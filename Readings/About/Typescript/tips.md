
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