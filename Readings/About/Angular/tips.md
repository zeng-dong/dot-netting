
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