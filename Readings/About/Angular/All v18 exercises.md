# upgrading
[Updating to Angular Material 18](https://angular-material.dev/articles/updating-to-angular-material-18)
_update Angular Material 17 to 18, with Material 2 and also Material 3_

[ustomizing Angular Material just got easier in v18](https://www.youtube.com/watch?v=DpCwKpZlcbg)


# from ground up
## Creating a `v18` Angular Project

```bash
npx @angular/cli@18.0.1 new angular-material-3
```

Then select `Sass (SCSS)` for styling and `No` for `SSR/SSG/Prerendering`.

```bash
? Which stylesheet format would you like to use? Sass (SCSS)     [ https://sass-lang.com/documentation/syntax#scss ]
? Do you want to enable Server-Side Rendering (SSR) and Static Site Generation (SSG/Prerendering)? No
```

## Adding Angular Material `v18`

```bash
ng add @angular/material@18.0.0
```

And select answers as below:

```bash
? Choose a prebuilt theme name, or "custom" for a custom theme: custom
? Set up global Angular Material typography styles? Yes
? Include the Angular animations module? Include and enable animations
```

## Creating basic app

create a simple application to see and understand basic usages of updated `SASS` `mixins` for M3 in Angular Material.

We are going to use [Angular Material Schematics](https://material.angular.io/guide/schematics) to generate components:

```bash
ng generate @angular/material:navigation layout
ng generate @angular/material:dashboard dashboard
ng generate @angular/material:address-form address-form
ng generate @angular/material:table table
ng generate @angular/material:tree tree
ng generate @angular/cdk:drag-drop drag-drop
```

## theming layout

### Create a file `src/app/layout/_layout-component.theme.scss` with below content:

```scss
@use "@angular/material" as mat;

@mixin theme($theme) {
  .sidenav-scroll-wrapper {
    background-color: rgba(mat.get-theme-color($theme, primary-container), 0.75);
  }
  .sidenav-content {
    @media (pointer: fine) {
      &::-webkit-scrollbar-thumb {
        background-color: mat.get-theme-color($theme, primary);
      }
    }
  }
}
```

Notice the usages of `get-theme-color` mixin:

1. To get color of the `primary-container` role, we used `mat.get-theme-color($theme, primary-container)`
2. To get color from tonal palette, we used `mat.get-theme-color($theme, primary)`.

To learn more, checkout [Reading tonal palette colors](https://material.angular.io/guide/material-3#reading-tonal-palette-colors) and [Reading color roles](https://material.angular.io/guide/material-3#reading-color-roles).

### then using layout component theme

Now, include and call this mixin in main `styles.scss` file:

```scss
@use "./app/layout/layout-component.theme";

:root {
    @include layout-component.theme($theme);
}
```



# follow pro angular 16
I use 18

node: nvm install 20.16.0  at 2014.08.12
nvm use 20.16.0
npm -v shows: 10.8.1

I use [local env setup]([Local set-up • Angular](https://angular.dev/tools/cli/setup-local))
1. install angular CLI: npm install -g @angular/cli
2. and 'ng version' 
Angular CLI: 18.1.4
Node: 20.16.0
Package Manager: npm 10.8.1
OS: win32 x64

Angular: undefined
...

Package                      Version
------------------------------------------------------
@angular-devkit/architect    0.1801.4 (cli-only)
@angular-devkit/core         18.1.4 (cli-only)
@angular-devkit/schematics   18.1.4 (cli-only)
@schematics/angular          18.1.4 (cli-only)

#### another way to install ng and create an app
npx -p @angular/cli@18 ng new my-app

then I create the example project (in his book he calls it exampleApp), mine is proangular:
ng new proangular --routing false --style css --skip-git --skip-tests

bootstrap
npm install bootstrap@5.2        (his is 5.2.3)
there is no schematics API so need manual change to angular.config file to include Bootstrap CSS stylesheet in the styles bundle. issue this command:
ng config projects.proangular.architect.build.options.styles 
'[""src/styles.css"",
""node_modules/bootstrap/dist/css/bootstrap.min.css""]'


# I add angular material
ng add @angular/material


# multi-apps
I use this command: npx -p @angular/cli@18 ng new multi-apps
my ng version (global): 18.1.4, and this command prompt me:  
```
Need to install the following packages:
@angular/cli@18.2.0
Ok to proceed? (y) y
```

I cd into multi-apps and 'ng serve', works



