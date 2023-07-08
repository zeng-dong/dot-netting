
# back button

### override
https://stackoverflow.com/questions/63905041/override-browser-back-button-functionality-in-angular

```typescript
import { LocationStrategy } from '@angular/common';

@Component({
  selector: 'app-root'
})
export class AppComponent {
  constructor(
    private location: LocationStrategy
  ) {
    history.pushState(null, null, window.location.href);
    // check if back or forward button is pressed.
    this.location.onPopState(() => {
        history.pushState(null, null, window.location.href);
        this.stepper.previous();
    });
  }
}
```

### disable browser back button popstate
```typescript
import { LocationStrategy } from '@angular/common';

/ Inject LocationStrategy Service into your component
    constructor(
        private locationStrategy: LocationStrategy
      ) { }


// Define a function to handle back button and use anywhere
    preventBackButton() {
        history.pushState(null, null, location.href);
        this.locationStrategy.onPopState(() => {
          history.pushState(null, null, location.href);
        })
      }
```

### Angular Location Service: go/back/forward
https://www.tektutorialshub.com/angular/angular-location-service/


## don't nest subscribes
[link](https://www.youtube.com/watch?v=KiJ-e5QuWe4)
Deborah Kurata

```typescript
user?: User;
todos: ToDo[] = [];

getUser(userName: string): void {
	this.http.get<User>(`${this.userUrl}/${userName}`).pipe(
		tap(user => this.user = user),
		tap( user => this.http.get<ToDo[]>(`${this.todoUrl}?userId=$[user.Id]`).pipe(
			tap( todos => this.todos = todos )
		).subscribe(console.log)			
		),
	).subscribe(console.log);
}

/// we can use higher-order mapping operators

user?: User;
todos: ToDo[] = [];

getUser(userName: string): void {
	this.http.get<User>(`${this.userUrl}/${userName}`).pipe(
		tap ( user => this.user = user ),
		switchMap ( user => 
			this.http.get<ToDo[]>( `${this.todoUrl}?userId=${user.id}` ).pipe(
				tap(todo => this.todos = todos )
			)
		)
	).subscribe();
}


```


## Deborah Kurata on composing 
[RxJS Best Practices Aren't Always Black and White](https://www.youtube.com/watch?v=rQTSMbeqv7I)

### Procedural vs Declarative
* Procedural
```typescript
getUsers(): Observable<User[]> {
	return this.http.get<User[]>(this.userUrl).pipe(
		catchError(this.handleError)
	);
}
```
* Declarative: declare a variable
```typescript
users$ = this.http.get<User[]>(this.userUrl).pipe(
	catchError(this.handleError)
);
```

instead of thinking about something you have to pass to a function, thinking about something you can react to

so
#### React to User Actions
1. Declare an action stream
```typescript
// Action stream
private userSelectedSubject = new Subject<number>();
userSelectedAction$ = this.userSelectedSubject.asObservable();
```
2. Emit a notification when the action occurs
```typescript
onSelected(userId: number): void {
	this.userSelectedSubject.next(userId);
}
```
3. React to that notification
```typescript
selectedUser$ = this.userSelectedAction$.pipe(
	switchMap((userId) =>
		this.http.get<User>(`${this.userUrl}/${userId}`).pipe(
			catchError(this.handleError)
		))
	);
```

#### when to use forkJoin
Great for getting related data for each item in an array
```typescript
usersWithTodos$ = this.http.get<User[]>(this.userUrl).pipe(
	mergeMap(users => 
		forkJoin(users.map(user =>
			this.http.get<ToDo[]>(`${this.todoUrl}?userId=${user.id}`)
				.pipe(
					map(todos => ({
						user,
						todos
					} as UserData))
				))
			))
		);
```




```



## Deborah Kurata's series on higher order mapping
[link](https://dev.to/deborahk/inner-observables-and-higher-order-mapping-hhe)
### inner observalbes and higher order mapping

### higher-order mapping operators
they are used to map inner Observables
* concatMap
* mergeMap
* switchMap

Each higher-order mapping operator:

- Automatically subscribes to the inner Observable
- Flattens the resulting Observable, returning `Observable<T>` instead of `Observable<Observable<T>>`
- Automatically unsubscribe from the inner Observable

```
products$ = this.categorySelected$
  .pipe(
       switchMap(catId=>
            this.http.get<Product[]>(`${this.url}?cat=${catId}`))
  );
```

In this code, every time the user selects a new category, `this.categorySelected$` emits the id of the selected category. 
That id is piped through a higher-order mapping operator (`switchMap` in this case). The `switchMap` automatically subscribes to the inner Observable, flattens the result (emitting an array of type `Product[]` instead of `Observable<Product[]>`), and unsubscribes from the inner Observable.

### concatMap


# refresh button
## disable
[link](https://www.itsolutionstuff.com/post/how-to-disable-browser-refresh-button-in-angularexample.html)

```typescript
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.css' ]
})

export class AppComponent implements OnInit  {
  name = 'Angular';

  ngOnInit(){
     window.addEventListener("keyup", disableF5);
     window.addEventListener("keydown", disableF5);

    function disableF5(e) {
	    
       if ((e.which || e.keyCode) == 116) e.preventDefault(); 
    };
  }
}
```



# to read:
https://dev.to/angular/simple-yet-powerful-state-management-in-angular-with-rxjs-4f8g
http://getgoingit.blogspot.com/2018/05/passing-value-from-one-observable-to.html
https://www.htmlgoodies.com/javascript/executing-rxjs-6-observables-in-order/

(https://gist.github.com/HighSoftWare96/4cd6380371553e3f37b227ae7431db92#how-to-prevent-angular-page-refresh)How to prevent Angular page refresh?
https://gist.github.com/HighSoftWare96/4cd6380371553e3f37b227ae7431db92

[5 RxJs-Angular pitfalls to be aware of](https://blog.angulartraining.com/5-rxjs-angular-pitfalls-to-be-aware-of-160adfd402d8)

[Form validation done right with vest](https://www.youtube.com/watch?v=EMUAtQlh9Ko)



# unit test
This one is for beginner and is very practical: https://www.youtube.com/@WebTechTalk/videos
	* no git repo but easy to follow

This one seems covering a lot of things (waitforasync, by.css, debug tests, etc.) in one hour:
https://www.youtube.com/watch?v=ic_Ez8PO_jc

This one demos how to test a component using shallow integration to pure isolated:
[Angular component testing - Overcoming the hurdles](https://www.youtube.com/watch?v=xJ45MGDAi6c)
code: https://bitbucket.org/LMFinney/unit-testing
and also they (angular boot camp) have a github examples: https://stackblitz.com/github/AngularBootCamp/async-unit-tests

this one has detailed setup for jest (removing jasmine and karma, install jest, ...):
https://www.youtube.com/watch?v=31or_m_xAA0

Testable angular forms ng-conf 2022: https://www.youtube.com/watch?v=rWXWXWMy2lE

Testing Angular components with Material Dialog
https://medium.com/@aleixsuau/testing-angular-components-with-material-dialog-mddialog-1ae658b4e4b3