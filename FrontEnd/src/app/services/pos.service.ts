import { RepositoryService } from './../shared/services/repository.service';
import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Brand } from '../_interface/inventory/brand';
import { PaginatedResult } from '../_interface/inventory/PaginateResult';
import { ProductParams } from '../_interface/inventory/productParams';
import { Category } from '../models/category';
import { Device } from '../_interface/inventory/device';
import { Employee } from '../_interface/inventory/employee';
import { CategoryParams } from '../_interface/inventory/categoryParams';
import { BrandParams } from '../_interface/inventory/brandParams';
import { EmployeeParams } from '../_interface/inventory/employeeParams';
import { Result } from '../_interface/inventory/Result';
import { CategoryapiService } from './categoryapi.service';
import { BrandapiService } from './brandapi.service';
import { CustomerapiService } from './customerapi.service';
import { ProductapiService } from './productapi.service';
import { MatTableDataSource } from '@angular/material/table';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PosService {

  public isCustomerLoading: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  constructor(private customerApi: CustomerapiService,private productApi :ProductapiService,
    private brandService:BrandapiService, private categoryService: CategoryapiService,
    private repoService: RepositoryService, ) { }

  // getCustomers(CustomerParams:EmployeeParams): Observable<PaginatedResult<Employee>> {
  //   let params = new HttpParams();
  //   if (CustomerParams.searchString) params = params.append('searchString', CustomerParams.searchString);
  //   if (CustomerParams.pageSize) params = params.append('pageSize', CustomerParams.pageSize);
  //   this.isCustomerLoading.next(true);
  //   return this.customerApi.getAlls(params)
  //     .pipe(map((response: PaginatedResult<Employee>) => {
  //       this.isCustomerLoading.next(false);
  //       return response;
  //     }));
  // }
  // getCustomerById(id: string): Observable<Result<Employee>> {
  //   return this.customerApi.getById(id).pipe(
  //     map((response: Result<Employee>) => response)
  //   );
  // }
  public dataSource = new MatTableDataSource<Device>();
  private allDevices: Device[] = [];
  public errorMessage: string = '';
  public filterForm: FormGroup;

  //  getAllDevices() {
  //   this.repoService.getData('api/devices').subscribe(
  //     (res) => {
  //       this.allDevices = res as Device[];
  //       this.dataSource.data = this.allDevices;
  //       this.applyFilter();
  //       console.log(this.dataSource.data);
  //     },
  //     (error) => {
  //       this.errorMessage = 'Failed to load devices. Please try again later.';
  //       console.error('Error fetching devices:', error);
  //     }
  //   );
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


  // getProducts(productParams: ProductParams): Observable<PaginatedResult<Device>>
  // {
  //   let params = new HttpParams();
  //   if (productParams.searchString) {
  //     params = params.append('searchString', productParams.searchString);
  //   }
  //   if (productParams.pageSize) {
  //     params = params.append('pageSize', productParams.pageSize.toString());
  //   }
  //   // if (productParams.brandIds.length > 0) {
  //   //   for (let i = 0; i < productParams.brandIds.length; i++) {
  //   //     params = params.append('brandIds', productParams.brandIds[i]);
  //   //   }
  //   // }
  //   if (productParams.categoryIds.length > 0) {
  //     for (let i = 0; i < productParams.categoryIds.length; i++) {
  //       params = params.append('categoryIds', productParams.categoryIds[i]);
  //     }
  //   }
  //   return this.productApi
  //     .getAlls(params)
  //     .pipe(map((response: PaginatedResult<Device>) => response));
  // }
  getProductById(id: string): Observable<Result<Device>> {
    return this.productApi.getById(id).pipe(
      map((response: Result<Device>) => response)
    );
  }
  getBrands(brandParams: BrandParams): Observable<PaginatedResult<Brand>> {
    let params = new HttpParams();
    if (brandParams.searchString)
      params = params.append('searchString', brandParams.searchString);
    if (brandParams.pageNumber)
      params = params.append('pageNumber', brandParams.pageNumber.toString());
    if (brandParams.pageSize)
      params = params.append('pageSize', brandParams.pageSize.toString());
    if (brandParams.orderBy)
      params = params.append('orderBy', brandParams.orderBy.toString());
    return this.brandService
      .getAlls(params)
      .pipe(map((response: PaginatedResult<Brand>) => response));
  }

  getCategories(categoryParams: CategoryParams): Observable<PaginatedResult<Category>> {
    let params = new HttpParams();
    if (categoryParams.searchString)
      params = params.append('searchString', categoryParams.searchString);
    if (categoryParams.pageNumber)
      params = params.append('pageNumber', categoryParams.pageNumber.toString());
    if (categoryParams.pageSize)
      params = params.append('pageSize', categoryParams.pageSize.toString());
    if (categoryParams.orderBy)
      params = params.append('orderBy', categoryParams.orderBy.toString());
    return this.categoryService
      .getAlls(params)
      .pipe(map((response: PaginatedResult<Brand>) => response));
  }

  // update
  getProducts(
    productParams: ProductParams
  ): Observable<PaginatedResult<Device>> {
    let params = new HttpParams();
    if (productParams.searchString) {
      params = params.append('searchString', productParams.searchString);
    }
    if (productParams.pageSize) {
      params = params.append('pageSize', productParams.pageSize.toString());
    }
    if (productParams.brandIds.length > 0) {
      for (let i = 0; i < productParams.brandIds.length; i++) {
        params = params.append('brandIds', productParams.brandIds[i]);
      }
    }
    if (productParams.categoryIds.length > 0) {
      for (let i = 0; i < productParams.categoryIds.length; i++) {
        params = params.append('categoryIds', productParams.categoryIds[i]);
      }
    }
    return this.productApi
      .getAlls(params)
      .pipe(map((response: PaginatedResult<Device>) => response));
  }

}
