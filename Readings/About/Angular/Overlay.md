Create floating panel on the screen

Almost every component which uses Overlay Module has 2 basic elements:

- **Connected Overlay** – some template which should be shown (tooltip text or any another HTML)
- **Overlay Origin** – HTML element on a page Connected Overlay should be attached to. In our case it is going to be an input element because I want to should our tooltip next to the input
# syntax
the standard way defined by Angular to use overlay inside the application,

```js
< ng-template cdkConnectedOverlay [cdkConnectedOverlayOrigin]="val" [cdkConnectedOverlayOpen]="val" >
```

We are trying to use and create the overlay using the different property provided by cdk, 
	cdkConnectedOverlay
	cdkConnectedOverlayOrigin
	cdkConnectedOverlayOpen

### How Does Overlay Work in Angular Material?
1. OverlayModule
2. methods
- **create:** This method id used to create the overlay.
- **position:** This method is used to configure and construct the position for overlay.
- **getContainerElement:** This method is used to get the container element of the overlay.
- **getFullscreenElement:** Open element and its child element into the Fullscreen mode.
- **global:** This method is used to create the global position for overlay.
- **add:** This method is used to add a new overlay on the list of the available overlay.
