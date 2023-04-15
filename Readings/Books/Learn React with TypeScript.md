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


## chapter 4 using React Hooks


