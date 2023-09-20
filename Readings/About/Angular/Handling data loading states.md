https://blog.dai.codes/handling-http-loadng-states-in-angular-with-rxjs/

# antipattern
``` typescript

/** * BAD PRACTICE EXAMPLE: DO NOT DO THIS! */

export class SomeComponent {  
	constructor(    
		private readonly activatedRoute: ActivatedRoute,    
		private readonly myDataService: MyDataService  ) {}  
		
		readonly loading$ = new BehaviorSubject<boolean>(false);  
		readonly error$ = new BehaviorSubject<HttpErrorResponse | Error | undefined>(undefined);  
		readonly myData$ = this.activatedRoute.params.pipe(    
			pluck('id'),    
			tap(() => {      
				this.loading$.next(true);      
				this.error$.next(undefined);    
			}),    
			switchMap(      (id) => this.myDataService.getMyData(id)
				.pipe(        
					catchError(error => {          
						this.error$.next(error);          
						return of(undefined);        
					}),        
					tap(() => this.loading$.next(false)),        
					startWith(undefined as void)      )    )  );}


```

```html
<my-loading-spinner *ngIf="loading$ | async"></my-loading-spinner>

<my-error-component *ngIf="error$ | async as error" [error]="error"></my-error-component>

<my-data-component *ngIf="myData$ | async as data" [data]="data"></my-data-component>
```


## One Observable to rule them all

Instead of driving the UI with three separate `Observable`s, we can create a "state" interface to wrap the entire state of the request (loading, error and data) and observe a stream of the state changes:

```typescript
export interface HttpRequestState<T> {  
	isLoading: boolean;  
	value?: T;  
	error?: HttpErrorResponse | Error;
}

export class SomeComponent {  
	constructor(    
		private readonly activatedRoute: ActivatedRoute,    
		private readonly myDataService: MyDataService  ) {}  
	
	readonly myDataState$: Observable<HttpRequestState<MyData>> = this.activatedRoute.params.pipe(    
		pluck('id'),    
		switchMap(      
			(id) => this.myDataService.getMyData(id).pipe(        
				map((value) => ({isLoading: false, value})),        
				catchError(error => of({isLoading: false, error})),        
				startWith({isLoading: true})      
			)    
		),  
	);
}
```

Now we have a much simpler pipe, and just one `Observable`. We can use this in our HTML template like so:

```html
<ng-container *ngIf="myDataState$ | async as data">  
	<my-loading-spinner *ngIf="data.isLoading"></my-loading-spinner>  
	
	<my-error-component *ngIf="data.error" [error]="data.error"></my-error-component>  
	
	<my-data-component *ngIf="data.value" [data]="data.value"></my-data-component>
	
</ng-container>
```