
# Built-in Services

## retrieving Angular version in code

## title service

## centralized error handler service




# inject and unit test

```typescript
import { Component, inject } from '@angular/core';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  template: '{{ userName }}'
})
export class UserComponent {
  private userService = inject(UserService);
  userName = this.userService.getUserName();
}

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UserComponent } from './user.component';
import { UserService } from './user.service';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;
  let userService: UserService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserComponent],
      providers: [UserService] 
    });

    fixture = TestBed.createComponent(UserComponent);
    component = fixture.componentInstance;
    userService = TestBed.inject(UserService); 
  });

  it('should display the user name', () => {
    spyOn(userService, 'getUserName').and.returnValue('Test User'); 

    fixture.detectChanges();

    expect(component.userName).toBe('Test User');
  });
});
```
Key Points:

- **TestBed.inject:**
    
    Use `TestBed.inject` to get an instance of a dependency that you want to mock or spy on.
    
- **Spying on Dependencies:**
    
    Utilize `spyOn` to mock the behavior of dependencies, allowing you to isolate the component under test.
    
- **detectChanges:**
    
    Call `fixture.detectChanges()` to trigger change detection and update the component's view.
    
- Testing Functions with `inject`:
    
    If you're testing functions that use `inject`, you can use `TestBed.runInInjectionContext` to create an injection context for the test.
    

Benefits of Using `inject` in Tests:

- **Cleaner Syntax:** Tests are more readable and less verbose.
- **Easier to Mock Dependencies:** Mocking dependencies becomes straightforward with `TestBed.inject`.
- **Improved Isolation:** Promotes better isolation of the component under test.