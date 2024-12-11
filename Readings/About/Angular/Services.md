
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
