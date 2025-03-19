
# multi layout: another repo I may want to take a look:

https://github.com/touhidrahman/ng-starter-no-semi-four-space/tree/main
# Multiple layouts in Angular

[![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%27200%27%20height=%27200%27/%3e)![Shashank Reddy Nallu's photo](

[Shashank Reddy Nallu](https://hashnode.com/@shashanktech)

·[Apr 10, 2024](https://shashankreddynallu.in/multiple-layouts-in-angular)·

4 min read

![Multiple layouts in Angular](

## [](https://shashankreddynallu.in/multiple-layouts-in-angular#heading-introduction "Permalink")

## Introduction

Have you ever found yourself struggling with implementing various layouts in your Angular application? Whether it's handling authorized and unauthorized views or incorporating layout variations for different routes?

**Don't worry!** We've got your back in untangling it all. We'll walk you through each step and share easy tips to make arranging things in Angular super simple. Let's work together to understand it and make your app's layout strong.

### [](https://shashankreddynallu.in/multiple-layouts-in-angular#heading-point-to-remember "Permalink")

### Point to remember

We should be aware that Angular renders the application with in the **<router-outlet></router-outlet>** tags.

## [](https://shashankreddynallu.in/multiple-layouts-in-angular#heading-steps-to-create-multiple-layouts "Permalink")

## Steps to create multiple layouts

- **Create an Enum:**  
    Create an Enum named **PageLayout** to define the various types of layout frames required by our application.
    

- ```
      export enum PageLayout {
          Authorized = 'authorized', // Key for authorized layout
          UnAuthorized = 'unauthorized', // Key for unauthorized layout
          Error = 'error' // Key for error layout
      }
    ```
    
- **Create a service:**
    
    create **_page-layout.service.ts_** as following:
    

- ```
      import { Injectable } from '@angular/core';
      import { PageLayout } from '../enums/page-layout.enum';
      import { Subject } from 'rxjs';
    
      @Injectable({
        providedIn: 'root'
      })
    
      export class PageLayoutService {
        private layoutSubject = new Subject<PageLayout>();
    
        public layout$ = this.layoutSubject.asObservable();
    
        setLayout(value: PageLayout) {
          this.layoutSubject.next(value);
        }
      }
    ```
    
- **Create a Resolver:**
    
    Resolvers are resolved prior to route navigation, ensuring completion before the page component renders. This makes them an ideal location within the service to establish the layout for a specific path.
    
    > **NOTE:**  
    > In this example, a functional resolver is being utilized. Adjustments may be needed if your Angular project is version 14 or earlier.
    

- ```
      import { inject } from '@angular/core';
      import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from '@angular/router';
      import { PageLayout } from '../enums/page-layout.enum';
      import { PageLayoutService } from '../services/page-layout.service';
    
      /**
       * Resolver sets the page layout type,
       * ensuring that the layout is available before navigating to the component.
      **/
      export const setLayout = (inputLayout: PageLayout): ResolveFn<void> => {
          return (_route: ActivatedRouteSnapshot, _state: RouterStateSnapshot) => {
              inject(PageLayoutService).setLayout(inputLayout)
          };
      }
    ```
    
- **Add the Resolver to Route Config file:**
    
    Add the resolver to the routes configuration. Once a route is resolved, the data will be accessible in the **PageLayoutService**.
    

- ```
      import { Routes } from '@angular/router';
      import { AuthGuard } from './core/guards/auth.guard';
      import { PageLayout } from './layout/enums/page-layout.enum';
      import { setLayout } from './layout/utilities/layout-resolver';
    
      export const routes: Routes = [
          {
              path: '',
              loadChildren: () => import('./modules/home/home.routes').then((m) => m.HOME_ROUTES),
              canActivate: [AuthGuard],
              resolve: {
                  layout: setLayout(PageLayout.Authorized)
              }
          },
          {
              path: 'auth',
              loadChildren: () => import('./modules/auth/auth.routes').then((m) => m.AUTH_ROUTES),
              resolve: {
                  layout: setLayout(PageLayout.UnAuthorized)
              }
          },
          {
              path: '**',
              loadComponent: () => import('./modules/pages/page-not-found/page-not-found.component').then((c) => c.PageNotFoundComponent),
              resolve: {
                  layout: setLayout(PageLayout.Error)
              }
          }
      ];
    ```
    
- **Create Layout Components:**  
    Create different layout components, such as authorized-layout, unauthorized-layout, error-layout, etc. Ensure that **<ng-content></ng-content>** tags are correctly placed for content projection. This is where your page component will be rendered.
    

```
  @Component({
    selector: 'authorized-layout',
    standalone: true,
    imports: [AuthorizedHeaderComponent],
    template: `
      <authorized-header />
      <div class="authorized-container">
          <ng-content />
      </div>
    `,
    styleUrl: './authorized-layout.component.scss'
  })
  export class AuthorizedLayoutComponent { }
```

```
  @Component({
    selector: 'unauthorized-layout',
    standalone: true,
    imports: [UnauthorizedHeaderComponent],
    template: `
      <unauthorized-header />
      <div class="unauthorized-container">
          <ng-content />
      </div>
    `,
    styleUrl: './unauthorized-layout.component.scss'
  })
  export class UnauthorizedLayoutComponent { }
```

- ```
      @Component({
        selector: 'error-layout',
        standalone: true,
        imports: [],
        template: `
          <div class="error-container">
              <ng-content />
          </div>
        `,
        styleUrl: './error-layout.component.scss'
      })
      export class ErrorLayoutComponent { }
    ```
    
- **Modify app-component.html:**  
    Let's define the frame components within the app component. With each navigation, we'll adjust the layout accordingly. Since the app component serves as the main hub for all other pages and child components in our app, think of it as the control center or switchboard.
    
    > For Angular Version 17 and later:
    

```
  @switch (pageLayoutService.layout$ | async) {  
      @case (PageLayout.Authorized) {
          <authorized-layout>
              <router-outlet />
          </authorized-layout>
      }

      @case (PageLayout.UnAuthorized) {
          <unauthorized-layout>
              <router-outlet />
          </unauthorized-layout>
      }

      @case (PageLayout.Error) {
          <error-layout>
              <router-outlet />
          </error-layout>
      }

      @default {
          <unauthorized-layout>
              <router-outlet />
          </unauthorized-layout>
      }
  }
```

> For Angular Version 17 and earlier

- ```
      <ng-container [ngSwitch]="pageLayoutService.layout$ | async">
          <authorized-layout *ngSwitchCase="PageLayout.Authorized">
              <router-outlet />
          </authorized-layout>
    
          <unauthorized-layout *ngSwitchCase="PageLayout.UnAuthorized">
              <router-outlet />
          </unauthorized-layout>
    
          <error-layout *ngSwitchCase="PageLayout.Error">
              <router-outlet />
          </error-layout>
    
          <unauthorized-layout *ngSwitchDefault>
              <router-outlet />
          </unauthorized-layout>
      </ng-container>
    ```
    
- **Modify app-component.ts:**
    

- ```
      import { CommonModule } from '@angular/common';
      import { Component } from '@angular/core';
      import { RouterOutlet } from '@angular/router';
      import { PageLayout } from './layout/enums/page-layout.enum';
      import { PageLayoutService } from './layout/services/page-layout.service';
      import { AuthorizedLayoutComponent } from './layout/components/authorized-layout/authorized-layout.component';
      import { UnauthorizedLayoutComponent } from './layout/components/unauthorized-layout/unauthorized-layout.component';
      import { ErrorLayoutComponent } from './layout/components/error-layout/error-layout.component';
    
      @Component({
        selector: 'app-root',
        standalone: true,
        imports: [CommonModule, RouterOutlet, AuthorizedLayoutComponent, UnauthorizedLayoutComponent, ErrorLayoutComponent],
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.scss']
      })
      export class AppComponent {
        readonly PageLayout = PageLayout;
    
        constructor(public pageLayoutService: PageLayoutService) {}
      }
    ```
    
- **Run the app:**
    
    You're all set! Now, launch the app and explore different routes. If you've assigned a specific layout to a path, you'll notice that the component renders accordingly with that layout. One thing to keep in mind with this approach is that you need to use the setLayout resolver for all routes. If no layout is specified, the service will retain the previously set route information, potentially causing a route to render in an unintended layout.
    

---