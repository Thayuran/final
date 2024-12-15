import { Component, Input, OnInit } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Device } from 'src/app/_interface/inventory/device';
import { ProductapiService } from 'src/app/services/productapi.service';
import { SalesService } from 'src/app/services/sales.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { PaymentPopupComponent } from '../payment-popup/payment-popup.component';
import { PaymentComponent } from '../payment/payment.component';
import { MatDialog } from '@angular/material/dialog';
import { CartService } from 'src/app/services/cart.service';
import { CartItem } from 'src/app/models/carts';

@Component({
  selector: 'app-cart',
  standalone: false,

  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{

  @Input() cart!: MatSidenav;
  cartItems: CartItem[];
  total: number = 0;

  products: any[] = [];
  //cartItems: any[] = [];
  selectedProduct: any;
  paymentMethod: string = 'cash';
  showPaymentModal: boolean = false;
  customerName: string = '';
  customerPhone: string = '';
  paymentAmount: number = 0;
  paymentType = '';


  constructor(
    private salesService: SalesService,private dialog: MatDialog,
    public cartService: CartService,public repoService: RepositoryService,
  ) {}

  ngOnInit() {
    this.loadCurrentCart();
    this.repoService.get().subscribe((data) => {
      this.total = 0;
      this.cartItems = data;
      console.log(this.cartItems);
      data.forEach(arg => {
        this.total += arg.total;
      });
    });
  }

  loadCurrentCart() {
    this.cartItems = this.repoService.loadCurrentCart();
    this.cartItems.forEach(arg => {
      this.total += arg.total;
    });
  }
  // loadProducts() {
  //   this.repoService.getData('api/devices').subscribe(
  //     (res) => {
  //        this.products =res as Device[];
  //        this.products=products;
  //   );
  // }


  // private getAllDevices() {
  //   this.repoService.getData('api/devices').subscribe(
  //     (res) => {
  //       this.allDevices = res as Device[];
  //       this.dataSource.data = this.allDevices;
  //       this.applyFilter();
  //     },
  //     (error) => {
  //       this.errorMessage = 'Failed to load devices. Please try again later.';
  //       console.error('Error fetching devices:', error);
  //     }
  //   );
  // }

  // addToCart() {
  //   if (this.selectedProduct) {
  //     const existingItem = this.cartItems.find(
  //       item => item.productId === this.selectedProduct.id
  //     );

  //     if (existingItem) {
  //       existingItem.quantity++;
  //     } else {
  //       this.cartItems.push({
  //         displayName: this.selectedProduct,
  //         quantity: 1
  //       });
  //     }
  //   }
  // }

  openCheckoutDialog() {
    // var checkOutData = new CheckOut();
    // checkOutData.cartId = this.cartService.cartId;
    // checkOutData.cartItems = this.cartItems;
    // checkOutData.customerId = this.cartService.currentCustomer.id;
    // const dialogRef = this.dialog.open(CheckoutComponent, {
    //   data: checkOutData,
    // });
    // dialogRef.afterClosed().subscribe(result => {
    // });
  }
  openClearCartDialog() {
    // const dialogRef = this.dialog.open(DeleteDialogComponent, {
    //   data: 'Do you want to clear this cart?',
    // });
    // dialogRef.afterClosed().subscribe((result) => {
    //   if (result) {
    //     this.cartService.clearCart();
    //   }
    // });
  }




  removeFromCart(item: any) {
    const index = this.cartItems.indexOf(item);
    if (index > -1) {
      this.cartItems.splice(index, 1);
    }
  }

  increaseQuantity(item: any) {
    item.quantity++;
  }

  decreaseQuantity(item: any) {
    if (item.quantity > 1) {
      item.quantity--;
    } else {
      this.removeFromCart(item);
    }
  }

  calculateTotal(): number {
    return this.cartItems.reduce(
      (total, item) => total + (item.price * item.quantity),
      0
    );
  }


  // Payment option selection
  onPaymentOptionSelect(type: string) {
    this.paymentType = type;
    if (type === 'cash') {
      this.openCashPaymentPopup();
    } else if (type === 'card') {
      this.processCardPayment();
    }
  }

 openCashPaymentPopup() {
    const dialogRef = this.dialog.open(PaymentPopupComponent, {
      data: { totalAmount: this.total }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result?.success) {
        this.salesService.processSale(result.data).subscribe(() => {
          alert('Payment Successful! Invoice sent to WhatsApp.');
        });
      }
    });
  }

  processCardPayment() {
    const dialogRef = this.dialog.open(PaymentComponent, {
      data: { totalAmount: this.total }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result?.success) {
        this.salesService.processSale(result.data).subscribe(() => {
          alert('Card Payment Successful! Invoice sent to WhatsApp.');
        });
      }
    });
  }

  proceedToPayment() {
    if (this.cartItems.length > 0) {
      this.showPaymentModal = true;
    }
  }

  processPayment() {
    if (this.paymentAmount >= this.calculateTotal()) {
      const saleData = {
        customerName: this.customerName,
        phoneNumber: this.customerPhone,
        totalAmount: this.calculateTotal(),
        paymentMethod: this.paymentMethod,
        saleItems: this.cartItems.map(item => ({
          productId: item.productId,
          quantity: item.quantity
        }))
      };

      this.salesService.processSale(saleData).subscribe(
        response => {
          alert('Payment Successful! Sale ID: ' + response.saleId);
          this.resetCart();
        },
        error => {
          alert('Payment Failed: ' + error.message);
        }
      );
    } else {
      alert('Insufficient Payment Amount');
    }
  }

  cancelPayment() {
    this.showPaymentModal = false;
  }

  resetCart() {
    this.cartItems = [];
    this.showPaymentModal = false;
    this.customerName = '';
    this.customerPhone = '';
    this.paymentAmount = 0;
  }
}
