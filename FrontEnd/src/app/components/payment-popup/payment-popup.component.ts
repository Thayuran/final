import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-payment-popup',
  standalone: false,
  templateUrl: './payment-popup.component.html',
  styleUrl: './payment-popup.component.scss'
})
export class PaymentPopupComponent {

  customerName = '';
  phoneNumber = '';
  totalAmount: number;
  receivedAmount: number;
  balance: number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<PaymentPopupComponent>
  ) {
    this.totalAmount = data.totalAmount;
  }

  calculateBalance() {
    this.balance = this.receivedAmount - this.totalAmount;
  }

  completeTransaction() {
    if (this.receivedAmount < this.totalAmount) {
      alert('Received amount is less than the total amount.');
      return;
    }
    this.dialogRef.close({
      success: true,
      data: {
        customerName: this.customerName,
        phoneNumber: this.phoneNumber,
        totalAmount: this.totalAmount,
        paymentType: 'cash'
      }
    });
  }
}
