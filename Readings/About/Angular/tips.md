![[Pasted image 20240722220627.png]]
# customize material mat-form-field style (material 17)

:host ::ng-deep .mdc-text-field--outlined .mdc-notched-outline__leading {
	border-color: blue !important;
}
:host ::ng-deep .mdc-text-field--outlined .mdc-notched-outline__notch {
	border-color: blue !important;
}
:host ::ng-deep .mdc-text-field--outlined .mdc-notched-outline__trailing {
	border-color: blue !important;
}

// now focus:
:host ::ng-deep .mdc-text-field--outlined.mdc-text-field--focused .mdc-notched-outline__leading {
	border-color: red !important;
}
:host ::ng-deep .mdc-text-field--outlined.mdc-text-field--focused .mdc-notched-outline__notch {
	border-color: red !important;
}
:host ::ng-deep .mdc-text-field--outlined.mdc-text-field--focused .mdc-notched-outline__trailing {
	border-color: red !important;
}

# customize angular material form field 
## input outline
#### change mat input color and background and font -Size on focus
::ng-deep .mdc-text-field--focusd:not(.mdc-text-field--disabled) .mdc-floating-label{
	 color: orangered;   // label color
	 background-color: yellow;       // label background
	 font-size: 14px !important;      // label font size
	 padding: 0 10px;                     // add padding in label
}
####  change mat input floating label bydefault color
::ng-deep .mdc-text-field:not(.mdc-test-field-disabled) .mdc-floating-label{
	color: red;
}

####  change lable font position
::ng-deep .mdc-text-field-wrapper .mat-mdc-form-field-flex .mdc-floating-label {
	top: 12 px !important;
	 font-size: 12px;	 
}

#### change label color, background & font-size when focus after change label position
::ng-deep .mat-mdc-form-field .mdc-text-field--outlined .mdc-notched-outline--upgraded .mdc-floating-label--float-above {
	color: red;
	top: 28px;
		position: relative !important;
		font-weight: 300 !important;
		background-color: green;
		--mat-mdc-form-field-floating-label-scale: 1.5;		
}

#### change mat input value color
::ng-deep .mdc-text-field:not(.mdc-text-field--disabled) .mdc-text-field__input::placeholder {
	color: red; 
	   
}

#### change mat input placeholder color
::ng-deep .mdc-text-field:not(.mdc-text-field--disabled) .mdc-text-field__input {
	color: red;    
	font-size: 12px !important;
}

#### change caret color on focus (|)
::ng-deep .mdc-text-field .mdc-text-field__input {
	caret-color: red;	
}

#### change mat input border color and width
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled) .mdc-notched-outline--leading,
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled) .mdc-notched-outline--notch,
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled) .mdc-notched-outline--trailing {
	border-color: red;
	border-width: 2px;
}

#### hover to change outline color 
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled):not(.mdc-text-field--focusd):hover .mdc-notched-outline__leading,
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled):not(.mdc-text-field--focusd):hover .mdc-notched-outline__notch,
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled):not(.mdc-text-field--focusd):hover .mdc-notched-outline__trailing{
	border-color: red;
}

#### focus to change border color 
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled).mdc-text-field--focusd .mdc-notched-outline__leading,
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled).mdc-text-field--focusd .mdc-notched-outline__notch,
::ng-deep .mdc-text-field--outlined:not(.mdc-text-field--disabled).mdc-text-field--focusd .mdc-notched-outline__trailing{
	border-color: red;
		border-width: 3px;
}

#### change mat form field input height
::ng-deep .mat-mdc-text-field-wrapper {
	height: 30px !important;
}

#### change mat form field inside input with text position 
::ng-deep .mat-mdc-input-element {
	top: -10px !important;
	position: relative !important;
}


// change input left side border-radius 
::ng-deep .mdc-text-field--outlined .mdc-notched-outline .mdc-notched-outline__leading { 
	border-top-left-radius: var(--mdc-shape-small, 12px) !important; 
	border-bottom-left-radius: var(--mdc-shape-small, 12px) !important; 
	} 
	
// change input right side border-radius 
::ng-deep .mdc-text-field--outlined .mdc-notched-outline .mdc-notched-outline__trailing { 
border-top-right-radius: var(--mdc-shape-small, 12px) !important; 
border-bottom-right-radius: var(--mdc-shape-small, 12px) !important; 
}
## input fill

#### change mat input color and background and font -Size on focus
::ng-deep .mdc-text-field--focusd:not(.mdc-text-field--disabled) .mdc-floating-label{
	 color: orangered;   // label color
	 background-color: yellow;       // label background
	 font-size: 14px !important;      // label font size
	 padding: 0 10px;                     // add padding in label
}

#### change mat input floating label bydefault color
::ng-deep .mdc-text-field:not(.mdc-test-field-disabled) .mdc-floating-label{
	color: red;
}

####  change label font position
::ng-deep .mdc-text-field-wrapper .mat-mdc-form-field-flex .mdc-floating-label {
	top: 12 px !important;
	 font-size: 12px;	 
}
#### change mat input value color
::ng-deep .mdc-text-field:not(.mdc-text-field--disabled) .mdc-text-field__input {
	color: red; 	   
}

#### change mat input placeholder color
::ng-deep .mdc-text-field:not(.mdc-text-field--disabled) .mdc-text-field__input::placeholder {
	color: red;
	font-size: 12px !important; 	   
}

#### change caret color on focus (|)
::ng-deep .mdc-text-field .mdc-text-field__input {
	caret-color: red;	
}
#### change bottom border color 
::ng-deep .mdc-text-field--filled:not(.mdc-text-field--disabled) .mdc-line-ripple::before {
	border-bottom-color: rgba(212, 0, 0, 0.42);
}

#### hover to change bottom border color
::ng-deep .mdc-text-field--filled:not(.mdc-text-field--disabled):hover .mdc-line-ripple::before {
	border-bottom-color: rgba(212, 0, 0, 0.42);
}

#### focus to change bottom border color
::ng-deep .mdc-text-field--filled .mdc-line-ripple::after {
	border-bottom: 2px solid rgba(212, 0, 0, 0.42);
}

#### change padding 
::ng-deep .mat-mdc-text-field-wrapper:not(.mdc-text-field--outlined) .mat-mdc-form-field-infix {
	padding-top: 24px;
	padding-bottom: 8px; 
}

#### focus to change background color
::ng-deep .mat-mdc-form-field-focus-overlay {
	background-color: red;
	opacity: 0.8;
}

#### remove background color
::ng-deep .mdc-text-field--filled:not(.mdc-text-field--outlined) {
	background-color: transparent !important
}


#### hover to change background color
::ng-deep .mdc-text-field.mat-focused .mat-mdc-form-field-focus-overlay {
	opacity: 0;
}


# mat button customization
# ByDefault Theme Color

  
  

• Mat-Buttons with the current theme, you have the option to apply color using the color property. This allows you to set the background color of buttons to primary, accent, or warn, based on your preference.

  

## import the Angular Material Button Module File

  

app.module.ts

import {MatButtonModule} from '@angular/material/button';

import {MatIconModule} from '@angular/material/icon';

  

## ByDefault Mat Basic Button

  

app.component.html

<!----------- Primary Theme ------------>

<button mat-button color="primary" > Primary Theme </button>

<!----------- Accent Theme ------------->

<button mat-button color="accent" > Accent Theme </button>

<!----------- Warn Theme --------------->

<button mat-button color="warn" > Warn Theme </button>

  

app.component.scss

// Primary Theme Change css

.mat-mdc-button.mat-mdc-button-base, .mat-mdc-raised-button.mat-mdc-button-base, .mat-mdc-outlined-button.mat-mdc-button-base {

height: 45px !important; // change button height

width: 90px !important; // change button width

-moz-osx-font-smoothing: grayscale; // for font-smooth

-webkit-font-smoothing: antialiased; // for font-smooth

font-family: Arial, Helvetica, sans-serif // change button font family

font-size: var(--mdc-typography-button-font-size, 17px); // change button font size

line-height: var(--mdc-typography-button-line-height, 36px); // change button font line-height

font-weight: var(--mdc-typography-button-font-weight, 400); // change button font-weight

letter-spacing: var(--mdc-typography-button-letter-spacing, 0.7px); // change button font-weight

}

  

// Primary Theme Change css

.mat-mdc-button.mat-primary {

--mdc-text-button-label-text-color: #0f8bff !important; // change button background color

--mat-mdc-button-ripple-color: rgba(255, 209, 83, 0.4) !important; // change button font color

--mat-mdc-button-persistent-ripple-color: #0f8bff !important; // click to change button ripple color

}

.mat-mdc-button.mat-primary:hover {

background-color: rgba(255, 209, 83, 0.1);

}

  

// Accent Theme Change css

.mat-mdc-button.mat-accent {

--mdc-text-button-label-text-color: #ff6497!important;

--mat-mdc-button-ripple-color: rgba(255, 100, 151, 0.4) !important;

--mat-mdc-button-persistent-ripple-color: #ff6497 !important;

}

.mat-mdc-button.mat-accent:hover {

background-color: rgba(255, 209, 83, 0.1);

}

  

// Warn Theme Change css

.mat-mdc-button.mat-warn {

--mdc-text-button-label-text-color: #ff7b71 !important;

--mat-mdc-button-ripple-color: rgba(255, 123, 113, 0.4) !important;

--mat-mdc-button-persistent-ripple-color: #ff7b71 !important;

}

.mat-mdc-button.mat-warn:hover {

background-color: rgba(255, 123, 113, 0.08);

}

  

.mat-mdc-button {

margin: 0 5px; // change margin between two buttons

}

  

  
  

## ByDefault Mat Raised Button

  

app.component.html

<!----------- Primary Theme ------------>

<button mat-raised-button color="primary" > Primary Theme </button>

<!----------- Accent Theme ------------->

<button mat-raised-button color="accent" > Accent Theme </button>

<!----------- Warn Theme --------------->

<button mat-raised-button color="warn" > Warn Theme </button>

  

app.component.scss

// Primary Theme Change css

.mat-mdc-button.mat-mdc-button-base, .mat-mdc-raised-button.mat-mdc-button-base, .mat-mdc-outlined-button.mat-mdc-button-base {

height: 45px !important; // change button height

width: 90px !important; // change button width

-moz-osx-font-smoothing: grayscale; // for font-smooth

-webkit-font-smoothing: antialiased; // for font-smooth

font-family: Arial, Helvetica, sans-serif // change button font family

font-size: var(--mdc-typography-button-font-size, 17px); // change button font size

line-height: var(--mdc-typography-button-line-height, 36px); // change button font line-height

font-weight: var(--mdc-typography-button-font-weight, 400); // change button font-weight

letter-spacing: var(--mdc-typography-button-letter-spacing, 0.7px); // change button font-weight

}

  

// Primary Theme Change css

.mat-mdc-raised-button.mat-primary {

--mdc-protected-button-container-color: #0f8bff !important // change button background color

--mdc-protected-button-label-text-color: #fff !important; // change button font color

--mat-mdc-button-ripple-color: rgba(255, 0, 0, 0.4) !important; // click to change button ripple color

}

.mat-mdc-button.mat-primary:hover {

--mdc-protected-button-container-color: #005baf !important; // hover to change button background color

--mdc-protected-button-label-text-color: #fff !important; // hover to change button font color

}

  

// Accent Theme Change css

mat-mdc-raised-button.mat-accent {

--mdc-protected-button-container-color: #ff2d73; // change button background color

--mdc-protected-button-label-text-color: #fff; // change button font color

--mat-mdc-button-ripple-color: rgba(255, 187, 0, 0.6) !important; // click to change button ripple color

}

.mat-mdc-button.mat-accent :hover {

--mdc-protected-button-container-color: #d10046 !important; // hover to change button background color

--mdc-protected-button-label-text-color: #fff !important; // hover to change button font color

}

  

// Warn Theme Change css

mat-mdc-raised-button.mat-warn {

--mdc-protected-button-container-color: #ff261e; // change button background color

--mdc-protected-button-label-text-color: #fff; // change button font color

--mat-mdc-button-ripple-color: rgba(0, 204, 17, 0.6) !important; // click to change button ripple color

}

.mat-mdc-button.mat-warn :hover {

--mdc-protected-button-container-color: #d40700 !important; // hover to change button background color

--mdc-protected-button-label-text-color: #fff !important; // hover to change button font color

}

  

mat-mdc-raised-button {

margin: 0 5px; // change margin between two buttons

border-radius: none !important; // remove border-radius in button

}

  

  
  

## ByDefault Mat Stroked Button

  

app.component.html

<!----------- Primary Theme ------------>

<button mat-stroked-button color="primary" > Primary Theme </button>

<!----------- Accent Theme ------------->

<button mat-stroked-button color="accent" > Accent Theme </button>

<!----------- Warn Theme --------------->

<button mat-stroked-button color="warn" > Warn Theme </button>

  

app.component.scss

// Primary Theme Change css

.mat-mdc-button.mat-mdc-button-base, .mat-mdc-raised-button.mat-mdc-button-base, .mat-mdc-outlined-button.mat-mdc-button-base {

height: 45px !important; // change button height

width: 90px !important; // change button width

-moz-osx-font-smoothing: grayscale; // for font-smooth

-webkit-font-smoothing: antialiased; // for font-smooth

font-family: Arial, Helvetica, sans-serif // change button font family

font-size: var(--mdc-typography-button-font-size, 17px); // change button font size

line-height: var(--mdc-typography-button-line-height, 36px); // change button font line-height

font-weight: var(--mdc-typography-button-font-weight, 400); // change button font-weight

letter-spacing: var(--mdc-typography-button-letter-spacing, 0.7px); // change button font-weight

}

  

// Primary Theme Change css

.mat-mdc-outlined-button.mat-primary {

--mdc-outlined-button-label-text-color: #0f8bff !important; // change button font color

--mat-mdc-button-ripple-color: rgba(15, 139, 255, 0.8) !important; // change button ripple color

--mat-mdc-button-persistent-ripple-color: #000 !important; // change button persistent ripple color

--mdc-outlined-button-outline-color: #0f8bff !important; // change button outline color

}

.mat-mdc-outlined-button.mat-primary:active {

--mdc-outlined-button-label-text-color: #fff !important; // click to change button font color

}

  

// Accent Theme Change css

.mat-mdc-outlined-button.mat-accent {

--mdc-outlined-button-label-text-color: #ff4081 !important; // change button font color

--mat-mdc-button-ripple-color: rgba(255, 64, 129, 0.8) !important // change button ripple color

--mat-mdc-button-persistent-ripple-color: #000 !important; // change button persistent ripple color

--mdc-outlined-button-outline-color: #0f8bff !important; // change button outline color

}

.mat-mdc-outlined-button.mat-accent:active {

--mdc-outlined-button-label-text-color: #fff !important; // click to change button font color

}

  

// Warn Theme Change css

.mat-mdc-outlined-button.mat-warn {

--mdc-outlined-button-label-text-color: #f44336 !important; // change button font color

--mat-mdc-button-ripple-color: rgba(244, 67, 54, 0.8) !important; // change button ripple color

--mat-mdc-button-persistent-ripple-color: #000 !important; // change button persistent ripple color

--mdc-outlined-button-outline-color: #f44336 !important; // change button outline color

}

.mat-mdc-outlined-button.mat-warn:active {

--mdc-outlined-button-label-text-color: #fff !important; // click to change button font color

}

  

.mat-mdc-outlined-button {

margin: 0 5px; // change margin between two buttons

}

  

  
  

## ByDefault Mat Flat Button

  

app.component.html

<!----------- Primary Theme ------------>

<button mat-flat-button color="primary" > Primary Theme </button>

<!----------- Accent Theme ------------->

<button mat-flat-button color="accent" > Accent Theme </button>

<!----------- Warn Theme --------------->

<button mat-flat-button color="warn" > Warn Theme </button>

  

app.component.scss

// Primary Theme Change css

mat-mdc-unelevated-button.mat-primary {

--mdc-filled-button-container-color: #0f8bff !important; // change button background color

--mdc-filled-button-label-text-color: #fff; // change button font color

}

// Accent Theme Change css

mat-mdc-unelevated-button.mat-accent {

--mdc-filled-button-container-color: #ff2d73 !important; // change button background color

--mdc-filled-button-label-text-color: #fff; // change button font color

}

// Warn Theme Change css

mat-mdc-unelevated-button.mat-warn {

--mdc-filled-button-container-color: #ff261e !important; // change button background color

--mdc-filled-button-label-text-color: #fff; // change button font color

}

// button opacity fill when keyboard tab key use

::ng-deep .mat-mdc-button.cdk-program-focused .mat-mdc-button-persistent-ripple::before, ::ng-deep .mat-mdc-button.cdk-keyboard-focused .mat-mdc-button-persistent-ripple::before, ::ng-deep .mat-mdc-outlined-button.cdk-program-focused .mat-mdc-button-persistent-ripple::before, ::ng-deep .mat-mdc-outlined-button.cdk-keyboard-focused .mat-mdc-button-persistent-ripple::before {

opacity: 0.5; // change button persistent ripple opacity

}

  

  
  

## ByDefault Mat Icon Button

  

app.component.html

<!----------- Primary Theme ------------>

<button mat-icon-button color="primary">  
    <mat-icon> home </mat-icon>  
</button>

<!----------- Accent Theme ------------->

<button mat-icon-button color="accent">  
    <mat-icon> bookmark </mat-icon>  
</button>

<!----------- Warn Theme --------------->

<button mat-icon-button color="warn">  
    <mat-icon> favorite </mat-icon>  
</button>

  

app.component.scss

// Icon Button

.mat-icon {

height: 40px !important; // change button height

width: 40px !important; // change button width

overflow: auto !important; // for button overflow

font-size: var(--mdc-typography-button-font-size, 40px); // change button font size

}

  

// Primary Theme Change css

.mat-mdc-icon-button.mat-primary {

--mdc-icon-button-icon-color: #0f8bff !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #0f8bff !important; // change button ripple color

--mat-mdc-button-ripple-color: rgba(15, 139, 255, 0.1) !important; // change button persistent ripple color

}

// Accent Theme Change css

.mat-mdc-icon-button.mat-accent {

--mdc-icon-button-icon-color: #ff2d73 !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #ff2d73 !important; // change button ripple color

--mat-mdc-button-ripple-color: rgba(255, 45, 115, 0.1) !important; // change button persistent ripple color

}

// Warn Theme Change css

.mat-mdc-icon-button.mat-warn {

--mdc-icon-button-icon-color: #ff261e !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #ff261e !important; // change button ripple color

--mat-mdc-button-ripple-color: rgba(255, 38, 30, 0.1) !important; // change button persistent ripple color

}

  

.mat-mdc-icon-button.mat-mdc-button-base {

width: 50px !important; // change button base width

height: 50px !important; // change button base height

padding: 10px 7px !important; // change button base padding

}

  

.mat-mdc-icon-button {

margin: 0 5px; // change margin between two buttons

}

  

  
  

## ByDefault Mat FAB Button

  

app.component.html

<!----------- Primary Theme ------------>

<button mat-fab color="primary">class="matFab1">  
    <mat-icon> home </mat-icon>  
</button>

<!----------- Accent Theme ------------->

<button mat-fab color="accent">class="matFab2">  
    <mat-icon> bookmark </mat-icon>  
</button>

<!----------- Warn Theme --------------->

<button mat-fab color="warn">class="matFab3">  
    <mat-icon> favorite </mat-icon>  
</button>

  

app.component.scss

// Primary Theme Change css

.matFab1 .mat-icon {

height: 25px !important; // change button height

width: 25px !important; // change button width

overflow: auto !important; // for button overflow

font-size: var(--mdc-typography-button-font-size, 25px); // change button font size

}

.mat-mdc-fab.mat-primary {

--mdc-fab-container-color: #0f8bff !important; // change button background color

--mat-mdc-fab-color: #ffd000 !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #fff !important; // change button persistent ripple color

--mat-mdc-button-ripple-color: rgba(255, 255, 255, 0.1) !important; // change button ripple color

padding: 10px 8px !important; // change button padding

}

  
  

// Accent Theme Change css

.matFab2 .mat-icon {

height: 25px !important; // change button height

width: 25px !important; // change button width

overflow: auto !important; // for button overflow

font-size: var(--mdc-typography-button-font-size, 30px); // change button font size

}

.mat-mdc-fab.mat-accent {

--mdc-fab-container-color: #ff4081 !important; // change button background color

--mat-mdc-fab-color: #ffd000 !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #fff !important; // change button persistent ripple color

--mat-mdc-button-ripple-color: rgba(255, 255, 255, 0.1) !important; // change button ripple color

padding: 10px 8px !important; // change button padding

}

  
  

// Warn Theme Change css

.matFab3 .mat-icon {

height: 35px !important; // change button height

width: 35px !important; // change button width

overflow: auto !important; // for button overflow

font-size: var(--mdc-typography-button-font-size, 35px); // change button font size

}

.mat-mdc-fab.mat-warn{

--mdc-fab-container-color: #f44336 !important; // change button background color

--mat-mdc-fab-color: #ffd000 !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #fff !important; // change button persistent ripple color

--mat-mdc-button-ripple-color: rgba(255, 255, 255, 0.1) !important; // change button ripple color

padding: 10px 8px !important; // change button padding

}

  
  

.mat-mdc-fab {

margin: 0 5px; // change margin between two buttons

}

  

  
  

## ByDefault Mat Mini-FAB Button

  

app.component.html

<!----------- Primary Theme ------------>

<button mat-mini-fab color="primary">class="matMiniFab1">  
    <mat-icon> bookmark </mat-icon>  
</button>

<!----------- Accent Theme ------------->

<button mat-mini-fab color="accent">class="matMiniFab2">  
    <mat-icon> favorite </mat-icon>  
</button>

<!----------- Warn Theme --------------->

<button mat-mini-fab color="warn">class="matMiniFab3">  
    <mat-icon> delete </mat-icon>  
</button>

  

app.component.scss

// Primary Theme Change css

.matMiniFab1 .mat-icon {

height: 20px !important; // change button height

width: 20px !important; // change button width

overflow: auto !important; // for button overflow

font-size: var(--mdc-typography-button-font-size, 20px); // change button font size

}

.mat-mdc-mini-fab.mat-primary {

--mdc-fab-container-color: #0f8bff !important; // change button background color

--mat-mdc-fab-color: #ffd000 !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #fff !important; // change button persistent ripple color

--mat-mdc-button-ripple-color: rgba(255, 255, 255, 0.1) !important; // change button ripple color

padding: 10px 8px !important; // change button padding

}

  
  

// Accent Theme Change css

.matMiniFab2 .mat-icon {

height: 25px !important; // change button height

width: 25px !important; // change button width

overflow: auto !important; // for button overflow

font-size: var(--mdc-typography-button-font-size, 25px); // change button font size

}

.mat-mdc-mini-fab.mat-accent {

--mdc-fab-container-color: #ff4081 !important; // change button background color

--mat-mdc-fab-color: #ffd000 !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #fff !important; // change button persistent ripple color

--mat-mdc-button-ripple-color: rgba(255, 255, 255, 0.1) !important; // change button ripple color

padding: 10px 8px !important; // change button padding

}

  
  

// Warn Theme Change css

.matMiniFab3 .mat-icon {

height: 30px !important; // change button height

width: 30px !important; // change button width

overflow: auto !important; // for button overflow

font-size: var(--mdc-typography-button-font-size, 30px); // change button font size

}

.mat-mdc-mini-fab.mat-warn{

--mdc-fab-container-color: #f44336 !important; // change button background color

--mat-mdc-fab-color: #ffd000 !important; // change button icon color

--mat-mdc-button-persistent-ripple-color: #fff !important; // change button persistent ripple color

--mat-mdc-button-ripple-color: rgba(255, 255, 255, 0.1) !important; // change button ripple color

padding: 10px 8px !important; // change button padding

}

  
  

.mat-mdc-icon-button {

margin: 0 5px; // change margin between two buttons

}

# back button
npm package [angular-disable-browser-back-button](https://github.com/Zatikyan/angular-disable-browser-back-button)]

### Applying Postel's Law

When designing the models to use with your web API, you should keep in mind Postel's Law, also known as the robustness principle. It applies to systems that must interoperate with one another. Postel's Law states, "Be conservative in what you send, but be liberal in what you accept."

### override
https://stackoverflow.com/questions/63905041/override-browser-back-button-functionality-in-angular

```typescript
import { LocationStrategy } from '@angular/common';

@Component({
  selector: 'app-root'
})
export class AppComponent {
  constructor(
    private location: LocationStrategy
  ) {
    history.pushState(null, null, window.location.href);
    // check if back or forward button is pressed.
    this.location.onPopState(() => {
        history.pushState(null, null, window.location.href);
        this.stepper.previous();
    });
  }
}
```

### disable browser back button popstate
```typescript
import { LocationStrategy } from '@angular/common';

/ Inject LocationStrategy Service into your component
    constructor(
        private locationStrategy: LocationStrategy
      ) { }


// Define a function to handle back button and use anywhere
    preventBackButton() {
        history.pushState(null, null, location.href);
        this.locationStrategy.onPopState(() => {
          history.pushState(null, null, location.href);
        })
      }
```

### Angular Location Service: go/back/forward
https://www.tektutorialshub.com/angular/angular-location-service/


## don't nest subscribes
[link](https://www.youtube.com/watch?v=KiJ-e5QuWe4)
Deborah Kurata

```typescript
user?: User;
todos: ToDo[] = [];

getUser(userName: string): void {
	this.http.get<User>(`${this.userUrl}/${userName}`).pipe(
		tap(user => this.user = user),
		tap( user => this.http.get<ToDo[]>(`${this.todoUrl}?userId=$[user.Id]`).pipe(
			tap( todos => this.todos = todos )
		).subscribe(console.log)			
		),
	).subscribe(console.log);
}

/// we can use higher-order mapping operators

user?: User;
todos: ToDo[] = [];

getUser(userName: string): void {
	this.http.get<User>(`${this.userUrl}/${userName}`).pipe(
		tap ( user => this.user = user ),
		switchMap ( user => 
			this.http.get<ToDo[]>( `${this.todoUrl}?userId=${user.id}` ).pipe(
				tap(todo => this.todos = todos )
			)
		)
	).subscribe();
}


```


## Deborah Kurata on composing 
[RxJS Best Practices Aren't Always Black and White](https://www.youtube.com/watch?v=rQTSMbeqv7I)

### Procedural vs Declarative
* Procedural
```typescript
getUsers(): Observable<User[]> {
	return this.http.get<User[]>(this.userUrl).pipe(
		catchError(this.handleError)
	);
}
```
* Declarative: declare a variable
```typescript
users$ = this.http.get<User[]>(this.userUrl).pipe(
	catchError(this.handleError)
);
```

instead of thinking about something you have to pass to a function, thinking about something you can react to

so
#### React to User Actions
1. Declare an action stream
```typescript
// Action stream
private userSelectedSubject = new Subject<number>();
userSelectedAction$ = this.userSelectedSubject.asObservable();
```
2. Emit a notification when the action occurs
```typescript
onSelected(userId: number): void {
	this.userSelectedSubject.next(userId);
}
```
3. React to that notification
```typescript
selectedUser$ = this.userSelectedAction$.pipe(
	switchMap((userId) =>
		this.http.get<User>(`${this.userUrl}/${userId}`).pipe(
			catchError(this.handleError)
		))
	);
```

#### when to use forkJoin
Great for getting related data for each item in an array
```typescript
usersWithTodos$ = this.http.get<User[]>(this.userUrl).pipe(
	mergeMap(users => 
		forkJoin(users.map(user =>
			this.http.get<ToDo[]>(`${this.todoUrl}?userId=${user.id}`)
				.pipe(
					map(todos => ({
						user,
						todos
					} as UserData))
				))
			))
		);
```




```



## Deborah Kurata's series on higher order mapping
[link](https://dev.to/deborahk/inner-observables-and-higher-order-mapping-hhe)
### inner observalbes and higher order mapping

### higher-order mapping operators
they are used to map inner Observables
* concatMap
* mergeMap
* switchMap

Each higher-order mapping operator:

- Automatically subscribes to the inner Observable
- Flattens the resulting Observable, returning `Observable<T>` instead of `Observable<Observable<T>>`
- Automatically unsubscribe from the inner Observable

```
products$ = this.categorySelected$
  .pipe(
       switchMap(catId=>
            this.http.get<Product[]>(`${this.url}?cat=${catId}`))
  );
```

In this code, every time the user selects a new category, `this.categorySelected$` emits the id of the selected category. 
That id is piped through a higher-order mapping operator (`switchMap` in this case). The `switchMap` automatically subscribes to the inner Observable, flattens the result (emitting an array of type `Product[]` instead of `Observable<Product[]>`), and unsubscribes from the inner Observable.

### concatMap


# refresh button
## disable
[link](https://www.itsolutionstuff.com/post/how-to-disable-browser-refresh-button-in-angularexample.html)

```typescript
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.css' ]
})

export class AppComponent implements OnInit  {
  name = 'Angular';

  ngOnInit(){
     window.addEventListener("keyup", disableF5);
     window.addEventListener("keydown", disableF5);

    function disableF5(e) {
	    
       if ((e.which || e.keyCode) == 116) e.preventDefault(); 
    };
  }
}
```



# to read:
https://dev.to/angular/simple-yet-powerful-state-management-in-angular-with-rxjs-4f8g
http://getgoingit.blogspot.com/2018/05/passing-value-from-one-observable-to.html
https://www.htmlgoodies.com/javascript/executing-rxjs-6-observables-in-order/

(https://gist.github.com/HighSoftWare96/4cd6380371553e3f37b227ae7431db92#how-to-prevent-angular-page-refresh)How to prevent Angular page refresh?
https://gist.github.com/HighSoftWare96/4cd6380371553e3f37b227ae7431db92

[5 RxJs-Angular pitfalls to be aware of](https://blog.angulartraining.com/5-rxjs-angular-pitfalls-to-be-aware-of-160adfd402d8)

[Form validation done right with vest](https://www.youtube.com/watch?v=EMUAtQlh9Ko)



# unit test
This one is for beginner and is very practical: https://www.youtube.com/@WebTechTalk/videos
	* no git repo but easy to follow

This one seems covering a lot of things (waitforasync, by.css, debug tests, etc.) in one hour:
https://www.youtube.com/watch?v=ic_Ez8PO_jc

This one demos how to test a component using shallow integration to pure isolated:
[Angular component testing - Overcoming the hurdles](https://www.youtube.com/watch?v=xJ45MGDAi6c)
code: https://bitbucket.org/LMFinney/unit-testing
and also they (angular boot camp) have a github examples: https://stackblitz.com/github/AngularBootCamp/async-unit-tests

this one has detailed setup for jest (removing jasmine and karma, install jest, ...):
https://www.youtube.com/watch?v=31or_m_xAA0

Testable angular forms ng-conf 2022: https://www.youtube.com/watch?v=rWXWXWMy2lE

Testing Angular components with Material Dialog
https://medium.com/@aleixsuau/testing-angular-components-with-material-dialog-mddialog-1ae658b4e4b3

# custom validator
```typescript

export function notEarlierThan(numberOfDays: number): ValidatorFn {
  return (c: AbstractControl): { [key: string]: boolean } | null => {
    var inputDate = new Date(c.value);
    var comparedToDate = new Date(new Date().setDate(new Date().getDate() - numberOfDays));

    if (inputDate < comparedToDate) {
      return { 'notEarlierThan': true };
    }
    return null;
  }
}

```


# higher-order mapping operators

```typescript

supplierWitherMap$ = of(1, 5, 8)
	.pipe(
		map(id => this.http.get<Supllier>(`https://someapi/supplier/${id}`))
	);
...
this.supplierWitherMap$.subscribe( 
	i => console.log('map result', i)
);           // map result Observable {source: Observable, operator: f}

this.supplierWitherMap$.subscribe( o => o.subscribe(
	i => console.log('map result', i)
));           // map result {id: 1, name: 'supplier one', ...}


```

* family of operators: xxxMap();
* map each value
	* from a source(outer) Observable
	* to a new(inner) Oberservable
* automatically subscribe to/unsubscribe from inner Observables
* flattern the result
* emit the resulting values to the output Observable


### using concatMap for above nested subs
```typescript
of(1, 5, 8)
	.pipe(
		concatMap(id => this.http.get<Apple>(`${this.url}/${id}`))
	).subscribe(item => console.log(item));
```


# I used to put error
## like this:
```html
<mat-form-field>
  <input formControlName="dob" matInput placeholder="Birthdate" id="dob" />
  <mat-error *ngIf="entityForm.controls.dob.invalid && entityForm.controls.dob.errors.minimalAge">Must be >= 18 years</mat-error>
  <mat-error *ngIf="entityForm.controls.dob.invalid && entityForm.controls.dob.errors.required">Birthdate is required</mat-error>
  <mat-error *ngIf="entityForm.controls.dob.invalid && entityForm.controls.dob.errors.usDateFormat">Must be in US format: mm/dd/yyyy</mat-error>
  <mat-error *ngIf="entityForm.controls.dob.invalid && entityForm.controls.dob.errors.pizzaDateRange">{{dataService.PizzaDateRangeErrorMessage }}</mat-error>
</mat-form-field>
```


### use a getter and then
firstName.invalid && firstName.touched
### to satisfy typescript and also detect specific validity
firstName.errors?.['required'] && firstName.touched

### to highlight an input when it is invalid
<input formControlName="firstName" [class.error]="firstName.invalid && firsName.touched" ...
	   
## or like this
```html
<span class="invalid-feedback">
            <span *ngIf="customerForm.get('lastName').errors?.required">
              Please enter your last name.
            </span>
            <span *ngIf="customerForm.get('lastName').errors?.maxlength">
              The last name must be less than 50 characters.
            </span>
          </span>
```
and at the same time style the input like this:
```html
 <input class="form-control"
                 id="lastNameId"
                 type="text"
                 placeholder="Last Name (required)"
                 formControlName="lastName"
                 [ngClass]="{'is-invalid': (customerForm.get('lastName').touched ||
                                            customerForm.get('lastName').dirty) &&
                                            !customerForm.get('lastName').valid }" />
```

```typescript

function range(min: number, max: number): ValidatorFn {
	return (c: AbstractControl): {[key: string]: boolean} | null => {
		if ( c.value < min || c.value > max ){
			return {'range': true };
		}
		return null;
	}
}

```

# reacting to changes

## react to value changes
```typescript

controls.name.valueChanges
	//.pipe(distinctUntilChanged( (a, b) => JSON.stringify(a) === JSON.stringify(b) ))
	.pipe(distinctUntilChanged( this.stringifyCompare ))   // prevent potential infinite loop when value really changed
	.subscribe({
	next: (value) => {
		if ( value === ){
			fg.controls.email.addValidators([Validators.required]);
		}
		else {
			fg.controls.email.removeValidators([Validators.required]);
		}
		controls.email.updateValueAndValidity()	      // infinite loop possible  // use distinctUntilChanged
	
	}
});

stringifyCompare(a: any, b: any): boolean {
	return JSON.stringify(a) === JSON.stringify(b);
}

```

## adding reactive transformations
- more of rxjs

### debounceTime transformation

```typescript
subscribeToAddressChanges() {
	const addressGroup = this.form.controls.address;
	addressGroup.valueChanges.
		pipe(
			debounceTime(2000),
			distinctUntilChanged( this.stringifyCompare ))   
		.subscribe({
			next: (v) => {
				for( const controlName in addressGroup.controls ) {
					addressGroup.get(controlName)?.removeValidators([Validators.required]);
					addressGroup.get(controlName)?.updateValueAndValidity();
				}
			};
		});

	 // we sub to this valueChanges a seconde time
	addressGroup.valueChanges.
		pipe(distinctUntilChanged( this.stringifyCompare ))   
		.subscribe({
			next: (v) => {
				for( const controlName in addressGroup.controls ) {
					addressGroup.get(controlName)?.addValidators([Validators.required]);
					addressGroup.get(controlName)?.updateValueAndValidity();
				}
			};
		})

}

```


# my bootstrapping different modules
1. app module
2. app2 module
	1. can still name it app component
	2. can still give it app-root selector
	3. can still be a standalone
3. in main.ts
```typescript
import { bootstrapApplication } from '@angular/platform-browser';

// import { appConfig } from './app/app.config';
// import { AppComponent } from './app/app.component';
import { appConfig } from './app2/app.config';
import { AppComponent } from './app2/app.component';

bootstrapApplication(AppComponent, appConfig).catch((err) =>
  console.error(err)
);

```

# cli tips
ng new new-app --skip-install
ng new new-app --dry-run
ng new new-app --defaults