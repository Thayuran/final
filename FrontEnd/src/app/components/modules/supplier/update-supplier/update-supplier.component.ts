import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Supplier } from '../../../../models/supplier';

@Component({
  selector: 'app-update-supplier',
  standalone: false,

  templateUrl: './update-supplier.component.html',
  styleUrl: './update-supplier.component.css'
})
export class UpdateSupplierComponent {
  public supplierForm: FormGroup | any;
  private supplierId: string | null = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) { }

  hasError = (controlName: string, errorName: string) => {
    if (this.supplierForm.get(controlName).hasError(errorName))
      return true;

    return false;
  }

  updateSupplier = (supplierFormValue: any) => {
    if (this.supplierForm.valid)
      this.executeSupplierUpdate(supplierFormValue);
  }

  private executeSupplierUpdate = (supplierFormValue: any) => {
    const updatedSupplier: Supplier = {
      id: this.supplierId ? this.supplierId : '',
      name: supplierFormValue.name,
      contactInfo: supplierFormValue.contactInfo
    };
  }


  redirectToSupplierList = () => {
    this.router.navigate(['/ui-components/supplier']);
  }

}
