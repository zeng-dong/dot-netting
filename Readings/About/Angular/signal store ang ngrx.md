
# angular deep dive: NgRx

I have two projects in my monorepo: 
	ngrx-fundamentals: this is the starting project. The Product List component does everything: fetch, state man, display 
	ngrx-fundamentals-to-ngrx: convert to ngrx

### install and configure NgRx store to a project
npm install @ngrx/store @ngrx/effects
	zdnotes: as of 12/6/2025, I have to downgrade angular from 21 to 20 to be able to use latest ngrx
open the app.config file and register the ngrx store
	provideStore()
	provide Effects()
verify it works
	in a component, inject store, and in its ngOnInit: this.store.select(state => state).subscribe(s => console.log('App State: ', s));  and see output in dev console

### actions
they are events, not commands
naming: event source and category
dispatch

### reducers
pure functions
transition from state to next state

### effects

### selectors
the bridge between store and component
pure functions, for obtaining slices
memorized


# my first training

Welcome to this Guided Lab where you’ll build a product catalog app from scratch! You’ll use Angular’s Signal Store API to create reactive state containers, enabling your app to manage shared form data and async operations efficiently. You’ll configure stores with state, methods, computed signals, and RxJS methods; use effects for async workflows; integrate state for zoneless updates; compare to traditional patterns; and apply advanced techniques like computed business logic. The goal is to create a reactive app that handles state using modern practices, equipping you with skills for scalable Angular development.

The Signal Store API represents a modern evolution in Angular state management, offering built-in reactivity without external libraries. In this product app, it will allow seamless state sharing across components, reducing boilerplate compared to services or NgRx. Without reactive state, your app might rely on cumbersome observables or prop drilling—issues Signal Store solves for cleaner, testable code.

Signal-based updates enable zoneless change detection, improving performance in large apps. Learning Signal Store fundamentals will help you build efficient, maintainable applications, starting with this catalog manager.