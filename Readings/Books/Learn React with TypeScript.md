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
### Introducing React
### Using state
### Using events


## chapter 2 introducing TypeScript

## chapter 3 setting up React and TypeScript

## chapter 4 using React Hooks


