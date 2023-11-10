### validators 
``` typescript
import { Injectable } from '@angular/core';
import { ValidatorFn, AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class CustomValidatorsService {

  constructor() {}

  startBeforeEnd(startKey: string, endKey: string, errorKey: string): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      if (!control) { return null; }

      const start = control.get(startKey);
      const end = control.get(endKey);
      if (!start.value || !end.value) {
        return null;
      }

      const startDate = new Date(start.value);
      const endDate = new Date(end.value);

      if (!this.isValidDate(startDate) || !this.isValidDate(endDate)) {
        return null;
      } else if (startDate > endDate) {
        const obj = {};
        obj[errorKey] = true;
        return obj;
      }
      return null;
    };
  }

  passwordsMatch(passwordKey: string, confirmPasswordKey: string): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      if (!control) { return null; }

      const password = control.get(passwordKey);
      const confirmPassword = control.get(confirmPasswordKey);
      if (!password.value || !confirmPassword.value) {
        return null;
      }

      if (password.value !== confirmPassword.value) {
        return { passwordMismatch: true };
      }
      return null;
    };
  }

  private isValidDate(date: any): boolean {
    return date instanceof Date && !isNaN(Number(date));
  }
}
```

### not exactly unit tests
```typescript
import { CustomValidatorsService } from './custom-validators.service';
import { FormGroup, FormControl } from '@angular/forms';

describe('CustomValidatorsService', () => {
  const service = new CustomValidatorsService();

  it('passwordsMatch: should determine if two form control values match', () => {
    const mockFormGroup = new FormGroup({
      password: new FormControl('apples1'),
      confirmPassword: new FormControl('apples2')
    }, {
      validators: [service.passwordsMatch('password', 'confirmPassword')]
    });

    expect(mockFormGroup.status).toBe('INVALID');
    expect(mockFormGroup.errors['passwordMismatch']).toBe(true);
    mockFormGroup.patchValue({ confirmPassword: 'apples1' });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ password: '', confirmPassword: 'apples1' });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ password: 'apples1', confirmPassword: '' });
    expect(mockFormGroup.status).toBe('VALID');
  });

  it('startBeforeEnd: should determine if start date is before end date and assign error with error key', () => {
    const mockFormGroup = new FormGroup({
      start: new FormControl('2018-10-20'),
      end: new FormControl('2018-10-25')
    }, {
      validators: [service.startBeforeEnd('start', 'end', 'someError')]
    });

    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ start: '2018-10-25' , end: '2018-10-20' });
    expect(mockFormGroup.status).toBe('INVALID');
    expect(mockFormGroup.errors['someError']).toBe(true);
    mockFormGroup.patchValue({ start: '2018-10-25' , end: '2018-10-25' });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ start: 'gwegww' , end: '2018-10-25' });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ start: '2018-10-25' , end: 'efwfew' });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ start: '' , end: '2018-10-25' });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ start: '2018-10-25' , end: '' });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ start: '' , end: '' });
    expect(mockFormGroup.status).toBe('VALID');

    mockFormGroup.patchValue({ start: new Date('2018-10-20'), end: new Date('2018-10-25') });
    expect(mockFormGroup.status).toBe('VALID');
    mockFormGroup.patchValue({ start: new Date('2018-10-25') , end: new Date('2018-10-20') });
    expect(mockFormGroup.status).toBe('INVALID');
    mockFormGroup.patchValue({ start: new Date('2018-10-25') , end: new Date('2018-10-25') });
    expect(mockFormGroup.status).toBe('VALID');
  });
});
```

## example 2
```typescript

import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

import { CONSTANTS } from '../constants';

export class PasswordValidator {
  static validPassword(isRequired: boolean = false): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      if (!control.value) {
        return isRequired ? { invalidPassword: `Password is required.` } : null;
      }
      if (control.value.length < 8) {
        return { invalidPassword: `Password is too short.` };
      }
      if (!CONSTANTS.SYMBOL_REGEX.test(control.value)) {
        return {
          invalidPassword: `Password requires at least one special character.`,
        };
      }
      if (!CONSTANTS.DIGIT_REGEX.test(control.value)) {
        return {
          invalidPassword: `Password requires at least one numeric character.`,
        };
      }

      return null;
    };
  }
}


import { FormControl } from '@angular/forms';

import { PasswordValidator } from './password-validator';

describe('[Unit] PasswordValidator', () => {
  describe('validPassword() Required', () => {
    const passwordValidator = PasswordValidator.validPassword(true);
    const passwordControl = new FormControl('');

    it(`should return null if value matches RegEx`, () => {
      passwordControl.setValue('passwordTest1!');
      expect(passwordValidator(passwordControl)).toEqual(null);
    });

    it(`should return { invalidPassword: 'Password is required.' } when value is an empty string`, () => {
      passwordControl.setValue('');
      const expectedValue = { invalidPassword: 'Password is required.' };
      expect(passwordValidator(passwordControl)).toEqual(expectedValue);
    });

    it(`should return { invalidPassword: 'Password is too short.' } when value is too short`, () => {
      passwordControl.setValue('test');
      const expectedValue = { invalidPassword: 'Password is too short.' };
      expect(passwordValidator(passwordControl)).toEqual(expectedValue);
    });

    it(`should return { invalidPassword: 'Password requires at least one special character.' } when missing special characters`, () => {
      passwordControl.setValue('passwordTest1');
      const expectedValue = {
        invalidPassword: 'Password requires at least one special character.',
      };
      expect(passwordValidator(passwordControl)).toEqual(expectedValue);
    });

    it(`should return { invalidPassword: 'Password requires at least one numeric character.' } when missing numeric characters`, () => {
      passwordControl.setValue('passwordTest!');
      const expectedValue = {
        invalidPassword: 'Password requires at least one numeric character.',
      };
      expect(passwordValidator(passwordControl)).toEqual(expectedValue);
    });
  });

  describe('validPassword() Not Required', () => {
    it(`should return null when value is an empty string`, () => {
      const passwordValidator = PasswordValidator.validPassword(false);
      const passwordControl = new FormControl('');
      passwordControl.setValue('');
      expect(passwordValidator(passwordControl)).toEqual(null);
    });

    it(`should return null when value is an empty string`, () => {
      const passwordValidator = PasswordValidator.validPassword();
      const passwordControl = new FormControl('');
      passwordControl.setValue('');
      expect(passwordValidator(passwordControl)).toEqual(null);
    });
  });
});


```


## example 3
```typescript
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export class MatchFieldValidator {
  static validFieldMatch(
    controlName: string,
    confirmControlName: string,
    fieldName: string = 'Password',
  ): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const controlValue: unknown | null = control.get(controlName)?.value;
      const confirmControlValue: unknown | null = control.get(
        confirmControlName,
      )?.value;

      if (!confirmControlValue) {
        control.get(confirmControlName)?.setErrors({
          confirmFieldRequired: `Confirm ${fieldName} is required.`,
        });
      }

      if (controlValue !== confirmControlValue) {
        control
          .get(confirmControlName)
          ?.setErrors({ fieldsMismatched: `${fieldName} fields do not match.` });
      }

      if (controlValue && controlValue === confirmControlValue) {
        control.get(confirmControlName)?.setErrors(null);
      }

      return null;
    };
  }
}


import { FormControl, FormGroup } from '@angular/forms';

import { MatchFieldValidator } from './match-field-validator';

describe('[Unit] MatchFieldValidator', () => {
  describe('validFieldMatch() default field name', () => {
    const matchFieldValidator = MatchFieldValidator.validFieldMatch(
      'controlName',
      'confirmControlName',
    );
    const form = new FormGroup({
      controlName: new FormControl(''),
      confirmControlName: new FormControl(''),
    });
    const controlName = form.get('controlName');
    const confirmControlName = form.get('confirmControlName');

    it(`should set control error as { confirmFieldRequired: 'Confirm Password is required.' } when value is an empty string`, () => {
      controlName?.setValue('');
      confirmControlName?.setValue('');
      matchFieldValidator(form);
      const expectedValue = {
        confirmFieldRequired: 'Confirm Password is required.',
      };
      expect(confirmControlName?.errors).toEqual(expectedValue);
    });

    it(`should set control error as { fieldsMismatched: 'Password fields do not match.' } when values do not match`, () => {
      controlName?.setValue('password123!');
      confirmControlName?.setValue('password123');
      matchFieldValidator(form);
      const expectedValue = {
        fieldsMismatched: 'Password fields do not match.',
      };
      expect(confirmControlName?.errors).toEqual(expectedValue);
    });

    it(`should set control error as null when values match`, () => {
      controlName?.setValue('password123!');
      confirmControlName?.setValue('password123!');
      matchFieldValidator(form);
      expect(controlName?.errors).toEqual(null);
      expect(confirmControlName?.errors).toEqual(null);
    });

    it(`should set control error as null when control matches confirm after not matching`, () => {
      controlName?.setValue('password123!');
      confirmControlName?.setValue('password123!');
      matchFieldValidator(form);
      controlName?.setValue('password123');
      matchFieldValidator(form);
      controlName?.setValue('password123!');
      matchFieldValidator(form);
      expect(controlName?.errors).toEqual(null);
      expect(confirmControlName?.errors).toEqual(null);
    });

    it(`should set control error as null when confirm matches control after not matching`, () => {
      controlName?.setValue('password123!');
      confirmControlName?.setValue('password123!');
      matchFieldValidator(form);
      controlName?.setValue('password123');
      matchFieldValidator(form);
      confirmControlName?.setValue('password123');
      matchFieldValidator(form);
      expect(controlName?.errors).toEqual(null);
      expect(confirmControlName?.errors).toEqual(null);
    });
  });

  describe(`validFieldMatch('Email') parameter field name`, () => {
    const matchFieldValidator = MatchFieldValidator.validFieldMatch(
      'controlName',
      'confirmControlName',
      'Email',
    );
    const form = new FormGroup({
      controlName: new FormControl(''),
      confirmControlName: new FormControl(''),
    });
    const controlName = form.get('controlName');
    const confirmControlName = form.get('confirmControlName');

    it(`should set control error as { confirmFieldRequired: 'Confirm Email is required.' } when value is an empty string`, () => {
      controlName?.setValue('');
      confirmControlName?.setValue('');
      matchFieldValidator(form);
      const expectedValue = {
        confirmFieldRequired: 'Confirm Email is required.',
      };
      expect(confirmControlName?.errors).toEqual(expectedValue);
    });

    it(`should set control error as { fieldsMismatched: 'Email fields do not match.' } when values do not match`, () => {
      controlName?.setValue('password123!');
      confirmControlName?.setValue('test@test.co');
      matchFieldValidator(form);
      const expectedValue = {
        fieldsMismatched: 'Email fields do not match.',
      };
      expect(confirmControlName?.errors).toEqual(expectedValue);
    });
  });
});


```

## example 4

``` typescript
import {Directive, Input, OnChanges, SimpleChanges} from "@angular/core";
import {
  AbstractControl, NG_VALIDATORS, NgModel, ValidationErrors, Validator, ValidatorFn,
  Validators
} from "@angular/forms";

@Directive({
  selector: '[fieldMatches]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: FieldMatchesValidatorDirective,
    multi: true
  }]
})
export class FieldMatchesValidatorDirective implements Validator, OnChanges {
  @Input() fieldMatches: NgModel;

  private validationFunction = Validators.nullValidator;

  ngOnChanges(changes: SimpleChanges): void {
    let change = changes['fieldMatches'];
    if (change) {
      const otherFieldModel = change.currentValue;
      this.validationFunction = fieldMatchesValidator(otherFieldModel);
    } else {
      this.validationFunction = Validators.nullValidator;
    }
  }

  validate(control: AbstractControl): ValidationErrors | any {
    return this.validationFunction(control);
  }
}

export function fieldMatchesValidator(otherFieldModel: NgModel): ValidatorFn {
  return (control: AbstractControl): ValidationErrors => {
    return control.value === otherFieldModel.value ? null : {'fieldMatches': {match: false}};
  };
}

/*
Now we could write **isolated unit tests** to test our validator, but these would only really be useful to verify our validation logic, which amounts to one line of code in this case. Or we could use Angular **testing utilities** to do something similar to an integration test, and see how our validator interacts with Angular and (most importantly) with a template.
*/


import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {Component} from "@angular/core";
import {async, ComponentFixture, ComponentFixtureAutoDetect, TestBed} from "@angular/core/testing";
import {By} from "@angular/platform-browser";

describe('FieldMatchesValidatorDirective', () => {
  let component: TestComponent;
  let fixture: ComponentFixture<TestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [CommonModule, FormsModule],
      declarations: [TestComponent],
      providers: [
        { provide: ComponentFixtureAutoDetect, useValue: true },
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestComponent);
    component = fixture.componentInstance;
  });

  it('should invalidate two fields that do not match', async(() => {
    component.field1 = '12345678901234';
    component.field2 = '12345678999999';

    fixture.detectChanges();
    fixture.whenStable().then(() => {
      fixture.detectChanges();

      let field2Model = fixture.debugElement.query(By.css('input[name=field2]')).references['field2Model'];

      expect(field2Model.valid).toBe(false);
    });
  }));
});

@Component({
  template: '<form #form1="ngForm">' +
            '<input name="field1" #field1Model="ngModel" [(ngModel)]="field1">' +
            '<input name="field2" #field2Model="ngModel" [fieldMatches]="field1Model" [(ngModel)]="field2">' +
            '</form>'
})
class TestComponent {
  field1: string;
  field2: string;
}

```