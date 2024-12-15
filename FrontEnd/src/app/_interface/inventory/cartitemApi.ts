import { CartItem } from "./cartitem";

export class CartItemApiModel extends CartItem {
  // id: string;
  // productId: string;
  // quantity: number;
  // productName: string;
  // rate: number;
  // constructor(productId: string, quantity: number) {
  //     this.productId = productId;
  //     this.quantity = quantity;
  // }
  constructor(
    
    displayName: string,
    quantity: number
  ) {
    super(displayName,quantity);
  }

}
