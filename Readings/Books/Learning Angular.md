Fourth Edition 
2023 Packt

# chapter 12 unit testing an Angular app
the tooling that the Angular framework and the Angular CLI provide us with
- Jasmine: We have already learned that this is the testing framework
- Karma: The test runner for running our unit tests
- Angular testing utilities: A set of helper methods that assist us in setting up our unit tests and writing our assertions in the context of the Angular framework

#### TestBed
A class that is the most crucial concept. It essentially creates a testing module that behaves like an ordinary Angular module. When we test an Angular artifact,
we detach it from the Angular module it resides in and attach it to this testing module. The TestBed class contains the configureTestingModule method we use to set up the
test module as needed.

#### ComponentFixture
A wrapper class around an Angular component instance. It allows us to interact with the component and its corresponding HTML element.

#### DebugElement
A wrapper around the DOM element of the component. It is an abstraction that operates cross-platform so that our tests are platform-independent.

## Testing components
