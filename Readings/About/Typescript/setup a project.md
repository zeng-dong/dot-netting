# steps
1. mkdir
2. cd into it
3. npm init -y
4. npm i -g typescript
5. tsc init --outDir dist --rootDir ts --sourceMap
6. in vs code config launch: 
	1. type: node
	2. program: ${file}

# add jest
npm i --save-dev jest
npm i --save-dev @type/jest
modify package.json script section: "test": "jest"
	so now we can run 'npm test'


