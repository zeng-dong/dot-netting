
# common use cases

## Authentication Interceptor
add authentication tokens to outgoing requests and handle authentication-related errors

``` typescript
import { Injectable } from '@angular/core';  
import {  
  HttpInterceptor,  
  HttpRequest,  
  HttpHandler,  
} from '@angular/common/http';  
  
@Injectable()  
export class AuthInterceptor implements HttpInterceptor {  
  intercept(request: HttpRequest<any>, next: HttpHandler) {  
    const authToken = 'your-auth-token';  
    const authRequest = request.clone({  
      headers: request.headers.set('Authorization', `Bearer ${authToken}`),  
    });  
    return next.handle(authRequest);  
  }  
}
```

## ## Error Handling Interceptor

to centralize error handling for HTTP requests. It can capture HTTP errors, log them, and perform appropriate actions like displaying error messages.

```typescript
import { Injectable } from '@angular/core';  
import {  
  HttpInterceptor,  
  HttpRequest,  
  HttpHandler,  
  HttpErrorResponse,  
} from '@angular/common/http';  
import { catchError } from 'rxjs/operators';  
import { throwError } from 'rxjs';  
  
@Injectable()  
export class ErrorInterceptor implements HttpInterceptor {  
  intercept(request: HttpRequest<any>, next: HttpHandler) {  
    return next.handle(request).pipe(  
      catchError((error: HttpErrorResponse) => {  
        // Handle and log the error here  
        console.error('HTTP Error:', error);  
        // Optionally rethrow the error to propagate it  
        return throwError(error);  
      })  
    );  
  }  
}
```