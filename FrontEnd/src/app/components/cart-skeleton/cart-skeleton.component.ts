import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-skeleton',
  standalone: false,

  templateUrl: './cart-skeleton.component.html',
  styleUrl: './cart-skeleton.component.css'
})
export class CartSkeletonComponent implements OnInit {
  cartItems = new Array();
  constructor() { }

  ngOnInit(): void {
  }
}
