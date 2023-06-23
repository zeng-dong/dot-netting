
# back button

### override
https://stackoverflow.com/questions/63905041/override-browser-back-button-functionality-in-angular

```typesript
```javascript
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