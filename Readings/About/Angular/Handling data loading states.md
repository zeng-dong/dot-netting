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

