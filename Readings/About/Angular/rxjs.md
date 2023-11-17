# combining data streams

productsWithCategory$ = combineLatest([
this.products$,
this.productCategories$
]);                                                                         ==> [product[], category[]]

productsWithCategory$ = forkJoin([
this.products$,
this.productCategories$
]);                                                                         ==> [product[], category[]]


``` typescript
// Mapping an Id to a String
productCategories$ = this.http.get<ProductCategory[]>(this.categoriesUrl);
products$ = this.http.get<Product[]>(this.url);
productsWithCategory$ = combineLatest([
	this.products$,
	this.productCategories$
]).pipe(
	map(([products, categories]) =>
		products.map(product => ({
			...product,
			price: product.price * 1.5,
			category: categories.find(
				c => product.categoryId === c.id
			).name
		} as Product)))
);

```


### given people, for each of them, get more info
using switchMap and mergeMap:

```typescript
getCharactersAndHomeworlds() {

    return this.http.get(this.baseUrl + 'people/')
      .pipe(
        switchMap((res: any) => {
          // convert array to observable
          return from(res.results);                      /// this will emit one person at a time
        }),
        // concatMap((person: any) => {
        mergeMap((person: any) => {                      /// for each person, we have a http.get, so multiple inner observable here, but we don't care about their specific order
            return this.http.get(person.homeworld)
              .pipe(
                map(hw => {
                  person.homeworld = hw;
                  return person;
                })
              );
        }),
        toArray()                                            /// another operator, so we get all in one batch
      );
  }
```