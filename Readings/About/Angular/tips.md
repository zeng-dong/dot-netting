
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
