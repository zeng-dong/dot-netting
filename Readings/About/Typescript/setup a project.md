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

so I simply create a folder, cd into the folder and execute the 3 command above, output of hello.ts is actually seen in console
no need to init a project or anything
## if globally
1. get node
2. npm i -g typescript
3. tsc --version
4. 