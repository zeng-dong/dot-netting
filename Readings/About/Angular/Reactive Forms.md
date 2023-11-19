# dynamically duplicate input elements
## steps
1. define the input elememt(s) to duplicate
2. define a FormGroup if needed
4. refactor to make copies
5. create a FormArray
6. in html loop through the FormArray
7. duplicate the input elements

### benefits of FormGroup
- match the value of the form model to the data model
- check touched, dirty, and valid state,
- watch for changes and react
- perform cross field validation
- dynamically duplicate the group

### FormArray
#### creation
- this.myArray = new FormArray([...]);
- this.myArray = this.fb.array([...]);

#### use a getter to easy access
get addresses(): FormArray {
    return <FormArray>this.customerForm.get['addresses'];
}


#### html
<div formArrayName="addresses" *ngFor="let address of addresses.controls; let i=index">
	<div [formGroupName]="i">
			<label attr.for={{ 'streetId' + i  }}  ....>Street </label>
		    <input .....  id={{ 'streetId' + i }}
	</div>
</div>