2nd edition
Packt March 2023
Carl Rippon
[source code](https://github.com/PacktPublishing/Learn-React-with-TypeScript-2nd-Edition)
[color images]( https://packt.link/5CvU5)


# Part 1 Introduction

## chapter 1 introducing React
online tools: 
- babel repl: https://babeljs.io/repl
- CodeSandbox: https://codesandbox.io/

### Understanding the benefits of React
### Understanding JSX
JSX is the syntax we use in a React component to define what the component should display
JavaScript XML
a JavaScript syntax extension. It does not execute directly in the browser.

> "use strict" statement: the JavaScript will be run in strict mode. Strict mode is where the JavaScript engine throws an error when it encounters problematic code rather than ignoring it

> /* # __ PURE __ * / comments: help bundlers such as webpack remove redundant code in the bundling process

### Creating a component
The StrictMode component will check the content inside it for potential problems and report them in the browser’s console. This is often referred to as React’s strict mode. The strict
mode in React is different from the strict mode in JavaScript, but their purpose of eliminating bad code is the same.

function Alert(){ return ( <div>abc xyz</div> ); }

const Alert = () => { return ( <div>abc xyz</div> ); }

### Understanding imports and exports
import and export statements allow JavaScript to be structured into modules

#### the importance of moduels
By default, JavaScript code executes in what is called the global scope. This means code from one file is automatically available in another file. 
Thankfully, JavaScript has a modules feature. A module’s functions and variables are isolated, so functions with the same name in different modules won’t collide.

#### using export statements
A module is a file with at least one export statement. 
An export statement references members that are available to other modules. Think of this as making members publicly available. 
A member can be a function, a class, or a variable within the file. Members not contained within the export statement are private and not available outside the module.

#### using import statements
**named** and **default** import statements

Unlike default imports, the names of imported members must match the exported members

### Using props
props make the component output flexible. Consumers of the component can pass appropriate props into the component to get the desired output

The *children* prop is actually a special prop used for the main content of components

- Props allow a component to be configured by the consuming JSX and are passed as JSX attributes
- Props are received in the component definition in an object parameter and can then be used in its JSX

### Introducing React
### Using state
The component **state** is a special variable containing information about the component’s current situation. For example, a component may be in a *loading* state or an *error* state.

state is a key part of making a component interactive
A change to a component state causes the component to refresh, more often referred to as **re-rendering**.

State is defined using a useState function from React
The useState function is one of React’s hooks
The syntax for useState is as follows:
``` javascript
const [state, setState] = useState(initialState);
```
- The initial state value is passed into useState. If no value is passed, it will initially be undefined.
- useState returns a tuple containing the current state value and a function to update the state value


### Using events
**Events** are another key part of allowing a component to be interactive
what React events are and how to use events on DOM elements
how to create our own React events

React events are a wrapper on top of the browser’s native events
Event handlers in React are generally registered to an element in JSX using an attribute
onClick={handleCloseClick}
onClick={() => {}}

#### custom event
A custom event in a component is implemented by implementing a prop. 
The prop is a function that is called to raise the event.
It is common practice to start an event prop name with on
   onClose

#zdnote so this can be used for parent to pass in a function to be called when things happen

What is wrong with how the click event is handled in the following JSX:
```javascript
<button click={() => console.log("clicked")}>
Click me
</button>;

// The problem is that a click prop is passed rather than onClick. Here’s the corrected JSX
<button onClick={() => console.log("clicked")}>
Click me
</button>;
```




## chapter 2 introducing TypeScript

## chapter 3 setting up React and TypeScript
#### create a project with webpack
#zdnote : skip (2023.04.14)

#### create a project with cra
generates a React and TypeScript project with all the common tools we will likely require, including CSS and unit testing support
command:
``` cmd
npx create-react-app myapp --template typescript
```

##### adding linting to visual studio code
CRA has already installed and configured ESLint in our project
editors can be integrated with ESLint
install ESLint extension (Microsoft)
open the Settings (File -> Preferences)
search eslint: probe
select the Worksapce tab
make sure that Typescript and typescriptreact are on the list
    if not, use the Add Item button

##### adding code formatting
install and configure Prettier in the project:
1. Install Prettier using the following command in the terminal in Visual Studio Code: 
``` cmd
npm i -D prettier
```
2. Prettier has overlapping style rules with ESLint, so install the following two libraries to allow Prettier to take responsibility for the styling rules from ESLint:
```cmd
npm i -D eslint-config-prettier eslint-plugin-prettier
```
eslint-config-prettier disables conflicting ESLint rules, and eslint-plugin-prettier is an ESLint rule that formats code using Prettier
3. The ESLint configuration needs to be updated to allow Prettier to manage the styling rules. Create React App allows ESLint configuration overrides in an eslintConfig section in package.json. Add the Prettier rules to the eslintConfig section in package.json as follows:
```json
{
...,
"eslintConfig": {
"extends": [
"react-app",
"react-app/jest",
"plugin:prettier/recommended"
]
},
...
}
```
4. Prettier can be configured in a file called .prettierrc.json. Create this file with the following content in the root folder:
```json
{
"printWidth": 100,
"singleQuote": true,
"semi": true,
"tabWidth": 2,
"trailingComma": "all",
"endOfLine": "auto"
}
```
We have specified the following:
	- Lines wrap at 100 characters
	- String qualifiers are single quotes
	- Semicolons are placed at the end of statements
	- The indentation level is two spaces
	- A trailing comma is added to multi-line arrays and objects
	- Existing line endings are maintained

Visual Studio Code can integrate with Prettier to automatically format code when source files are saved. So, let’s install a Prettier extension into Visual Studio Code
  open the Settings area in Visual Studio Code. Select the Workspace tab and make sure the Format On Save option is ticked
  There is one more setting to set. This is the default formatter that Visual Studio Code should use to format code. Click the Workspace tab and make sure Default Formatter is set to Prettier - Code formatter 

##### starting the app in dev mode
```
npm start
```


## chapter 4 using React Hooks


