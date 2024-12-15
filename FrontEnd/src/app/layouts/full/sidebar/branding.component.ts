import { Component } from '@angular/core';

@Component({
  selector: 'app-branding',
  template: `
    <div class="branding" display="flex" justify-content="center">
 <!-- <h1>IT Inventory</h1> -->
 <img src="../assets/logo.png" alt="loading..." width="200px" height="50px" align="center">

    </div>
  `,
})
export class BrandingComponent {
  constructor() {}
}
