export class CartItem {
  id: string='';
  productId: string;
  quantity: number;
  displayName: string;
  category: string;
  price: number;
  total: number=0;
  constructor(productId: string, quantity: number, displayName: string, category: string, price: number) {
      this.productId = productId;
      this.quantity = quantity;
      this.displayName = displayName;
      this.category = category;
      this.price =price;
  }
}
