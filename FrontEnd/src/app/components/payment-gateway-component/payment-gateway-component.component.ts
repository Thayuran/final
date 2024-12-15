import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-payment-gateway-component',
  standalone: false,
  templateUrl: './payment-gateway-component.component.html',
  styleUrl: './payment-gateway-component.component.scss'
})
export class PaymentGatewayComponentComponent {


  totalAmount: number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<PaymentGatewayComponentComponent>
  ) {
    this.totalAmount = data.totalAmount;
  }

  processPayment() {
    // Simulate payment gateway interaction
    setTimeout(() => {
      this.dialogRef.close({ success: true, data: { paymentType: 'card', totalAmount: this.totalAmount } });
    }, 2000);
  }

}
