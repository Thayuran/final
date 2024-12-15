import {HttpClient, HttpErrorResponse } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Brand } from 'src/app/_interface/inventory/brand';
import { Category } from 'src/app/_interface/inventory/category';
import { Device } from 'src/app/_interface/inventory/device';
import { Supplier } from 'src/app/_interface/inventory/supplier';
import { ErrorModalComponent } from 'src/app/shared/modals/error-modal/error-modal.component';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.css'],
})
export class DeviceComponent implements OnInit, AfterViewInit {
  bulkselectedFile: File | null = null;
  validationErrors: string[] = [];

  public categories: Category[] = [];
  public brands: Brand[] = [];
  public suppliers: Supplier[] = [];
  public filterForm: FormGroup;
  public errorMessage: string = '';
  public displayedColumns = [
    'image',
    'name',
    'serialNumber',
    'categoryName',
    'brandName',
    'supplierName',
    'isFaulty',
    'price',
    'quantity',
    'actions',
  ];
  public dataSource = new MatTableDataSource<Device>();
  private allDevices: Device[] = [];
  public bsModalRef?: BsModalRef;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private repoService: RepositoryService,
    private fb: FormBuilder,
    private errorService: RepositoryErrorHandlerService,
    private dialogService: DialogService,
    private modal: BsModalService,
    private router: Router,
    private authService: AuthenticationService,
    private http:HttpClient
  ) {}

  ngOnInit() {
    this.filterForm = this.fb.group({
      category: [''],
      brand: [''],
      supplier: [''],
    });

    this.loadDropdownData();
    this.getAllDevices();

    this.filterForm.valueChanges.subscribe(() => {
      this.applyFilter();
    });
  }

  private loadDropdownData = () => {
    this.repoService
      .getData('api/categories')
      .subscribe((res) => (this.categories = res as Category[]));

    this.repoService
      .getData('api/brands')
      .subscribe((res) => (this.brands = res as Brand[]));

    this.repoService
      .getData('api/suppliers')
      .subscribe((res) => (this.suppliers = res as Supplier[]));
  };

  private getAllDevices() {
    this.repoService.getData('api/devices').subscribe(
      (res) => {
        this.allDevices = res as Device[];
        this.dataSource.data = this.allDevices;
        this.applyFilter();
        console.log(this.dataSource.data);
      },
      (error) => {
        this.errorMessage = 'Failed to load devices. Please try again later.';
        console.error('Error fetching devices:', error);
      }
    );
  }

  // onImageSelected(event: Event): void {
  //   const file = (event.target as HTMLInputElement).files?.[0];
  //   if (file) {
  //     this.addDeviceForm.patchValue({ image: file });
  //     const reader = new FileReader();
  //     reader.onload = () => {
  //       this.imagePreview = reader.result;
  //     };
  //     reader.readAsDataURL(file);
  //   }
  // }


  private applyFilter() {
    const filters = this.filterForm.value;

    // Filter devices based on selected filters
    const filteredDevices = this.allDevices.filter((device) => {
      const matchesCategory =
        !filters.category || device.categoryName === filters.category;
      const matchesBrand = !filters.brand || device.brandName === filters.brand;
      const matchesSupplier =
        !filters.supplier || device.supplierName === filters.supplier;

      return matchesCategory && matchesBrand && matchesSupplier;
    });

    this.dataSource.data = filteredDevices;

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public doFilter(value: string) {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  public redirectToUpdate(id: string) {
    this.router.navigate([`/ui-components/update-device/${id}`]);
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public deleteDevice = (id: string) => {
    if (this.authService.isUserAdmin()) {
      this.dialogService
        .openConfirmDialog('Are you sure you want to delete this device?')
        .afterClosed()
        .subscribe((res) => {
          if (res) {
            this.repoService.delete(`api/devices/${id}`).subscribe(() => {
              const config: ModalOptions = {
                initialState: {
                  modalHeaderText: 'Success Message',
                  modalBodyText: `Device deleted successfully`,
                  okButtonText: 'OK',
                },
              };

              this.bsModalRef = this.modal.show(SuccessModalComponent, config);
              this.bsModalRef.content.redirectOnOk.subscribe(() =>
                this.getAllDevices()
              );
            });
          }
        });
    } else {
      const config: ModalOptions = {
        initialState: {
          modalHeaderText: 'Error Message',
          modalBodyText: 'Only Admin allowed',
          okButtonText: 'OK',
        },
      };
      this.modal.show(ErrorModalComponent, config);
    }
  };


  //check csv
  validateCsvFile(fileContent: string): boolean {
    const rows = fileContent.split('\n');
    for (const row of rows) {
      const values = row.split(',');
      const category = values[2];
      const brand = values[3];
      const supplier = values[4];

      if (
        !this.categories.find((c) => c.name === category) ||
        !this.brands.find((b) => b.name === brand) ||
        !this.suppliers.find((s) => s.name === supplier)
      ) {
        this.validationErrors.push(`Invalid category, brand, or supplier in row: ${row}`);
        return false;
      }
    }
    return true;
  }
  onFileSelectedBulk(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      const reader = new FileReader();
      reader.onload = (event: any) => {
        const fileContent = event.target.result;
        if (this.validateCsvFile(fileContent))
          {
          const formData = new FormData();
          formData.append('file',file);



      this.http.post('http://localhost:5000/api/devices/bulk', formData).subscribe(
        (response) => {
          console.log('Import successful', response);
          alert('Products imported successfully!');
        },
        (error) => {
          console.error('Import failed', error);
          alert('Failed to import products.');
        },
        );
        }
        else{
          console.error('Validation failed',this.validationErrors)
        }
      };
      reader.readAsText(file);
    }
  }
}
