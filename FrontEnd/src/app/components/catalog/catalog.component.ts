import { HttpClient } from '@angular/common/http';
import { CartService } from './../../services/cart.service';
import { AfterViewInit, Component,OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/_interface/inventory/brand';
import { Category } from 'src/app/_interface/inventory/category';
import { Device } from 'src/app/_interface/inventory/device';
import { PaginatedResult } from 'src/app/_interface/inventory/PaginateResult';
import { ProductParams } from 'src/app/_interface/inventory/productParams';
import { Supplier } from 'src/app/_interface/inventory/supplier';
import { PosService } from 'src/app/services/pos.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { MatTableDataSource } from '@angular/material/table';
import { BrandParams } from 'src/app/_interface/inventory/brandParams';
import { CategoryParams } from 'src/app/_interface/inventory/categoryParams';

@Component({
  selector: 'app-catalog',
  standalone: false,

  templateUrl: './catalog.component.html',
  styleUrl: './catalog.component.css'
})
export class CatalogComponent implements OnInit{
  searchString: string;
  brands: PaginatedResult<Brand>;
  brandParams = new BrandParams();
  brandAutoComplete = new FormControl();
  categories:PaginatedResult<Category>;
  categoryParams = new CategoryParams();
   products:PaginatedResult<Device>;
  productParams = new ProductParams();
  categoryAutoComplete = new FormControl();
  hasProductsLoaded: boolean = false;
  invalidCart: boolean = true;
  public dataSource = new MatTableDataSource<Device>();
  public filterForm: FormGroup;


  public categorieslist: Category[] = [];
  public brandslist: Brand[] = [];
  public supplierslist: Supplier[] = [];
constructor(
  public repoService: RepositoryService,
  private fb: FormBuilder,
  private errorService: RepositoryErrorHandlerService,
  private dialogService: DialogService,
  private modal: BsModalService,
  private router: Router,
  public authService: AuthenticationService,
  private http:HttpClient,
  public cartService:CartService,
  public posService: PosService,
  private toastr: ToastrService
) {}

ngOnInit(): void {

  this.filterForm = this.fb.group({
    category: [''],
    brand: [''],
    supplier: [''],
  });
  this.productParams.brandIds = [];
  this.productParams.categoryIds = [];
  this.productParams.pageSize = 16;
  this.brandParams.pageSize = 5;
  this.getProducts();
  this.getBrands();
  this.getAllDevices();

  this.loadDropdownData();
  this.filterForm.valueChanges.subscribe(() => {
    this.applyFilter();
  });
  // this.getCategories();
  this.brandAutoComplete.valueChanges.subscribe((value) => this._filterBrand(value));
  this.categoryAutoComplete.valueChanges.subscribe((value) => this._filterCategory(value));
}

// ngAfterViewInit() {
//   this.dataSource.sort = this.sort;
//   this.dataSource.paginator = this.paginator;
// }
public errorMessage: string = '';
private allDevices: Device[] = [];
private getAllDevices() {
  this.repoService.getData('api/devices').subscribe(
    (res) => {
      this.allDevices = res as Device[];
      this.dataSource.data = this.allDevices;
      this.applyFilter();
    },
    (error) => {
      this.errorMessage = 'Failed to load devices. Please try again later.';
      console.error('Error fetching devices:', error);
    }
  );
}
private loadDropdownData = () => {
  this.repoService
    .getData('api/categories')
    .subscribe((res) => (this.categorieslist = res as Category[]));

  this.repoService
    .getData('api/brands')
    .subscribe((res) => (this.brandslist = res as Brand[]));

  this.repoService
    .getData('api/suppliers')
    .subscribe((res) => (this.supplierslist = res as Supplier[]));
};



  getProducts() {
    this.hasProductsLoaded = false;
    this.posService.getProducts(this.productParams).subscribe((res) =>
      { this.products = res, this.hasProductsLoaded = true });

  }

  toggleBrandSelection($event:any, brand: Brand) {
    if ($event.checked) {
      if (!this.productParams.brandIds.includes(brand.id)) this.productParams.brandIds.push(brand.id);
    } else {
      if (this.productParams.brandIds.includes(brand.id)) this.productParams.brandIds = this.productParams.brandIds.filter(item => item !== brand.id);
    }
    this.getProducts();
  }

//  getBrandName(brandId: string): string {
//     const brand = this.brands?.data?.find(item => item.id === brandId);
//     return brand ? brand.name : 'Unknown Brand';
//   }

getBrands() {
  this.posService.getBrands(this.brandParams).subscribe((res) => { this.brands = res; });
}


  getBrandName(brandId: string): string | undefined {
    if (this.brands && this.brands.data)
      {
        const brand=this.brands.data.find(item => item.id === brandId);
        return brand? brand.name:undefined;
      }
      return undefined;
    }

    getCategories() {
      this.posService.getCategories(this.categoryParams).subscribe((res) => { this.categories = res; });
    }

    private _filterBrand(value: string) {
      const filterValue = value.toLowerCase();
      this.brandParams.searchString = filterValue;
      this.getBrands();
    }

    private _filterCategory(value: string) {
      const filterValue = value.toLowerCase();
      this.categoryParams.searchString = filterValue;
      this.getCategories();
    }

  //   isCheckedCategory(category: Category): boolean {
  //     if (this.productParams.categoryIds.includes(category.id)) return true;
  //     return false;
  //   }

  // isCheckedBrand(brand: Brand): boolean {
  //   if (this.productParams.brandIds.includes(brand.id)) return true;
  //   return false;
  // }

  // getCategoryName(categoryId: string): string {
  //   const category = this.categories?.data?.find(item => item.id === categoryId);
  //   return category ? category.name : 'Unknown Category';  // Provide a fallback name
  // }
  // getCategoryName(categoryId: string): string | undefined {
  //   const category = this.categories?.data?.find(item => item.id === categoryId);
  //   return category?.name;
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
public doFilter(value:string): void {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
    this.getProducts();
  }

  showImage: boolean = true;

  // toggleCategorySelection($event:any, category: Category) {
  //   if ($event.checked) {
  //     if (!this.productParams.categoryIds.includes(category.id)) this.productParams.categoryIds.push(category.id);
  //   } else {
  //     if (this.productParams.categoryIds.includes(category.id)) this.productParams.categoryIds = this.productParams.categoryIds.filter(item => item !== category.id);
  //   }
  //   this.getAllDevices();
  // }


  addToCart(product: Device) {
      this.repoService.add(product);
  }





  // // product showcase
  // public categories: Category[] = [];
  // public brands: Brand[] = [];
  // public suppliers: Supplier[] = [];
  // public filterForm: FormGroup;
  // public errorMessage: string = '';

  // public dataSource = new MatTableDataSource<Device>();
  // private allDevices: Device[] = [];
  // public bsModalRef?: BsModalRef;

  // @ViewChild(MatSort) sort: MatSort;
  // @ViewChild(MatPaginator) paginator: MatPaginator;



  // ngOnInit() {
  //   this.filterForm = this.fb.group({
  //     category: [''],
  //     brand: [''],
  //     supplier: [''],
  //   });

  //   this.loadDropdownData();
  //   this.getAllDevices();


  //   this.filterForm.valueChanges.subscribe(() => {
  //     this.applyFilter();
  //   });
  // }

  // private loadDropdownData = () => {
  //   this.repoService
  //     .getData('api/categories')
  //     .subscribe((res) => (this.categories = res as Category[]));

  //   this.repoService
  //     .getData('api/brands')
  //     .subscribe((res) => (this.brands = res as Brand[]));

  //   this.repoService
  //     .getData('api/suppliers')
  //     .subscribe((res) => (this.suppliers = res as Supplier[]));
  // };

  // private getAllDevices() {
  //   this.repoService.getData('api/devices').subscribe(
  //     (res) => {
  //       this.allDevices = res as Device[];
  //       this.dataSource.data = this.allDevices;
  //       this.applyFilter();
  //       this.hasProductsLoaded=true;
  //       console.log(this.dataSource.data);
  //     },
  //     (error) => {
  //       this.errorMessage = 'Failed to load devices. Please try again later.';
  //       console.error('Error fetching devices:', error);
  //     }
  //   );
  // }

  // private applyFilter() {
  //   const filters = this.filterForm.value;

  //   // Filter devices based on selected filters
  //   const filteredDevices = this.allDevices.filter((device) => {
  //     const matchesCategory =
  //       !filters.category || device.categoryName === filters.category;
  //     const matchesBrand = !filters.brand || device.brandName === filters.brand;
  //     const matchesSupplier =
  //       !filters.supplier || device.supplierName === filters.supplier;

  //     return matchesCategory && matchesBrand && matchesSupplier;
  //   });

  //   this.dataSource.data = filteredDevices;

  //   if (this.dataSource.paginator) {
  //     this.dataSource.paginator.firstPage();
  //   }
  // }

  // public doFilter(value: string) {
  //   this.dataSource.filter = value.trim().toLowerCase();
  // }



  // ngAfterViewInit() {
  //   this.dataSource.sort = this.sort;
  //   this.dataSource.paginator = this.paginator;
  // }


}
