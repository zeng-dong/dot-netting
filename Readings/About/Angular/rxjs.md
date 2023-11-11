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