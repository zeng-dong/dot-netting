3/12/2023
downloaded node v18.15.0, unzipped into my nvm folder
nvm use 18.15.0
npm install -g @angular/cli@latest: ng version: 15.2.2


# ng commands
- new (n): Creates a new Angular CLI workspace from scratch.
- build (b): Compiles an Angular application and outputs generated files in a predefined folder.
- generate (g): Creates new files that comprise an Angular application.
- serve (s): Builds an Angular application and serves it using a pre-configured web server.
- test (t): Runs unit tests of an Angular application.
- deploy: Deploys an Angular application to a web-hosting provider. You can choose from a collection of providers included in the Angular CLI.
- add: Installs an Angular library to an Angular application.
- completion: Enables auto-complete for Angular CLI commands through the terminal.
- update: Updates an Angular application to the latest Angular version


# model project
ng new model
cd into it
ng serve

# reactive forms poject

# material styling project
tsc --version
he use ng 14/2/3
I have ng 15.2.2

### steps
ng new using-material
no routing
scss
cd into it
ng serve

#### install Angular Material
one command: ng add@angular/material@14.2.2 ( I issued this: ng add @angular/material@15 )
this will add Material, Component Dev Kit (CDK), and Angular Animation
indigo/pink
y to set up global Angular Material typography styles
include animation

the command finished with these messages:
UPDATE package.json (1111 bytes)
✔ Packages installed successfully.
UPDATE src/app/app.module.ts (423 bytes)
UPDATE angular.json (3048 bytes)
UPDATE src/index.html (581 bytes)
UPDATE src/styles.scss (181 bytes)

remove  class="mat-typography" from body in index.html

remove two entries of "@angular/material/prebuilt-themes/indigo-pink.css" from angular.json and add @import '@angular/material/prebuilt-themes/indigo-pink.css' in styles.scss

create a shared module:
ng g m shared\material --dry-run --flat
remove commons, remove imports, only exports all material modules
imports this material module in app.module