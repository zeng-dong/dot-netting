# steps
## I adopted from PL Course "Using Arrays and Collections in Typescript"
1. mkdir
2. cd into it
3. npm init -y
4. npm i -g typescript
5. tsc init --outDir dist --rootDir ts --sourceMap
	1. this will create ts config file
6. in vs code config launch: 
	1. type: node
	2. program: ${file}
		so we can use a terminal to issue 'tsc -w' 
		and use debug console to 'F5'

# add jest
npm i --save-dev jest
npm i --save-dev @type/jest
modify package.json script section: "test": "jest"
	so now we can run 'npm test'




server:
node server.js
client:
npm run start


# 2025 setup - simpler than before with tsx

## if locally
1. npm i typescript --save-dev
2. npm i tsx --save-dev
3. npx tsx hello.ts

### add angular signals to this non-angular ts project
1. npm i @angular/core --save
2. update hello.ts like:
```javascript
import { signal } from "@angular/core";

console.log("hello world");
const s = signal<string>("hello signals");
console.log(s());
```
3. if I run 'npx tsx hello.ts' now I get error: 
```
node_modules/@angular/core/discovery.d.d.ts:73:23 - error TS2304: Cannot find name 'PromiseSettledResult'.

73     running?: Promise<PromiseSettledResult<void>[]>;
                         ~~~~~~~~~~~~~~~~~~~~

node_modules/rxjs/dist/types/internal/Observable.d.ts:117:35 - error TS2585: 'Promise' only refers to a type, but is being used as a value here. Do you need to change your target library? Try changing the 'lib' compiler option to es2015 or later.

117     toPromise(PromiseCtor: typeof Promise): Promise<T | undefined>;
                                      ~~~~~~~

Found 2 errors in 2 files.
Errors  Files
     1  node_modules/@angular/core/discovery.d.d.ts:73
     1  node_modules/rxjs/dist/types/internal/Observable.d.ts:117
```
4. to make this error go away: npm install @types/node --save
5. now I can run 'npx tsx hello.ts' and it works

### add rxjs to this non-angular project
same as adding angular/core
1. npm install rxjs --save
2. write rxjs code like 
```javascript
import { signal } from "@angular/core";
import { of } from "rxjs";
import { map } from "rxjs/operators";

console.log("hello world");
const s = signal<string>("hello signals");
console.log(s());

of(1, 2, 3)
    .pipe(map((x) => x * x))
    .subscribe((v) => console.log(`value: ${v}`));
```
3. run 'npx tsx hello.ts': it works

### to see the compiled js file
1. run npx tsc hello.ts
2. a "hello.js" is generated and you can view it.

so I simply create a folder, cd into the folder and execute the 3 command above, output of hello.ts is actually seen in console
no need to init a project or anything
## if globally
1. get node
2. npm i -g typescript
3. tsc --version
4. 