https://github.com/lara-newsom

true:
CanActivate
	Navigation continues
CanActivateChild
	Navigation continues
CanDeactivate
	Navigation continues
CanMatch
	Navigation continues

false:
CanActivate
	Navigation is canceled
CanActivateChild
	Navigation is canceled
CanDeactivate
	Navigation is canceled
CanMatch
	Navigation is skipped and the router continues checking remaining routes

```javascript
canMatch: [
	() => {
			const someService = inject(TheService);
			return  someService.featureFlags.pipe(map((flag) => !!flags.home))
			 }
]
```


## converting a class based guard to a chainable functional route guard

```typescript
import { Injectable, inject } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './services/auth.service';
import { map } from 'rxjs';
import { ROUTER_TOKENS } from './app.routes';

@Injectable({ providedIn: 'root' })
export class CartAuthGuard implements CanActivate {
  private authService = inject(AuthService);
  private router = inject(Router);

  canActivate() {
    return this.authService.userAuth.pipe(
      map((permissions) => !!permissions?.includes('cart') || this.router.parseUrl(`/${ROUTER_TOKENS.NOT_AUTH}`)))
  }
}
```

converting to

```typescript
export function authRouteGuard(route: string){
  return () => {
    const authService = inject(AuthService);
    const router = inject(Router);

    return authService.userAuth.pipe(
      map((permissions) =>
        !!permissions?.includes(route) || router.parseUrl(`/${ROUTER_TOKENS.NOT_AUTH}`
      )));
  }
}
```

### using const tokens
```typescript
export enum ROUTER_TOKENS {
  HOME = 'home',
  SHOP = 'shop',
  CONTACT = 'contact',
  ABOUT = 'about',
  CHECKOUT = 'checkout',
  CART = 'cart',
  NOT_AUTH = 'not-auth',
  NOT_READY = 'not-ready'
}

```


## testing functional route guard

```typescript
import { inject } from '@angular/core';
import { CanActivateFn, CanMatchFn, Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { AuthService } from '../auth.service';

export const isLoggedGuardFn: CanActivateFn = () => {
  const router = inject(Router);
  return inject(AuthService)
    .isLoggedIn$()
    .pipe(tap((isLoggedIn) => !isLoggedIn && router.navigate(['no-access'])));
};

export const canMatchGuardFn: CanMatchFn = () => {
  const router = inject(Router);
  return inject(AuthService)
    .isLoggedIn$()
    .pipe(tap((isLoggedIn) => !isLoggedIn && router.navigate(['no-access'])));
};
```

```typescript
import { TestBed, fakeAsync, tick } from '@angular/core/testing';
import { ActivatedRoute, Router, RouterStateSnapshot } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { isLoggedGuardFn } from '.';
import { AuthService } from '../auth.service';

describe('Functional Guards', () => {
  const authServiceSpy = jasmine.createSpyObj('AuthService', ['isLoggedIn$']);
  const mockRouter = jasmine.createSpyObj('Router', ['navigate']);
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      providers: [
        {
          provide: Router,
          useValue: mockRouter,
        },
        {
          provide: AuthService,
          useValue: authServiceSpy,
        },
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {},
          },
        },
      ],
    });
  });

  it('isLoggedIn guard should return true', fakeAsync(() => {
    const activatedRoute = TestBed.inject(ActivatedRoute);
    authServiceSpy.isLoggedIn$.and.returnValue(of(true));
    const guardResponse = TestBed.runInInjectionContext(() => {
      return isLoggedGuardFn(
        activatedRoute.snapshot,
        {} as RouterStateSnapshot
      ) as Observable<boolean>;
    });

    let guardOutput = null;
    guardResponse
      .pipe(delay(100))
      .subscribe((response) => (guardOutput = response));
    tick(100);

    expect(guardOutput).toBeTrue();
  }));

  it('isLoggedIn guard should return false', fakeAsync(() => {
    const activatedRoute = TestBed.inject(ActivatedRoute);
    authServiceSpy.isLoggedIn$.and.returnValue(of(false));
    const guardResponse = TestBed.runInInjectionContext(() => {
      return isLoggedGuardFn(
        activatedRoute.snapshot,
        {} as RouterStateSnapshot
      ) as Observable<boolean>;
    });

    let guardOutput = null;
    guardResponse
      .pipe(delay(100))
      .subscribe((response) => (guardOutput = response));
    tick(100);

    expect(guardOutput).toBeFalse();
    expect(mockRouter.navigate).toHaveBeenCalledWith(['no-access']);
  }));
});
```