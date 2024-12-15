export class CartItem {
  id: string;
  quantity: number;
  displayName: string;
  category: string;
  rate: number;
  total: number;
  constructor( displayName: string, quantity: number) {
      this.quantity = quantity;
      this.displayName = displayName;
     
  }
}
