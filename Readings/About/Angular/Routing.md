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