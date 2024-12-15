import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrandapiService } from 'src/app/services/brandapi.service';
import { CategoryapiService } from 'src/app/services/categoryapi.service';
import { ProductapiService } from 'src/app/services/productapi.service';
import { CustomerapiService } from 'src/app/services/customerapi.service';
import { CartService } from 'src/app/services/cart.service';



@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule
  ],
  providers: [
    BrandapiService, CategoryapiService, ProductapiService,
    CustomerapiService,CartService
  ],
})
export class ShareModule { }
