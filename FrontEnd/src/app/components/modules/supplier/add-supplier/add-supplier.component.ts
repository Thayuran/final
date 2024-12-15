import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Supplier } from '../../../../models/supplier';

@Component({
  selector: 'app-add-supplier',
  standalone: false,

  templateUrl: './add-supplier.component.html',
  styleUrl: './add-supplier.component.css'
})
export class AddSupplierComponent {
  public supplierForm: FormGroup | any;

  constructor(public router:Router){}

  hasError = (controlName: string, errorName: string) => {
    if (this.supplierForm.get(controlName).hasError(errorName))
      return true;

    return false;
  }

  createSupplier = (supplierFormValue: any) => {
    if (this.supplierForm.valid)
      this.executeSupplierCreation(supplierFormValue);
  }

  private executeSupplierCreation = (supplierFormValue: any) => {
    const supplier: Supplier = {
      name: supplierFormValue.name,
      contactInfo: supplierFormValue.contactInfo
    };
  }


  redirectToSupplierList = () => {
    this.router.navigate(['/ui-components/supplier']);
  }
}
