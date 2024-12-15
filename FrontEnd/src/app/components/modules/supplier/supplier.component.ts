import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { MatTableDataSource } from '@angular/material/table';
import { Supplier } from '../../../models/supplier';

@Component({
  selector: 'app-supplier',
  standalone: false,

  templateUrl: './supplier.component.html',
  styleUrl: './supplier.component.css'
})
export class SupplierComponent {

  public dataSource = new MatTableDataSource<Supplier>();

  constructor(

    private router: Router,
    private authService: AuthService
  ) {}


  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/ui-components/update-supplier/${id}`]);
  };

  public deleteSupplier = (id: string) => {}
}
