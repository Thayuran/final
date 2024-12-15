import { Injectable } from '@angular/core';
import { Brand } from '../_interface/inventory/brand';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../_interface/inventory/PaginateResult';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class BrandapiService {

  baseUrl = environment.apiUrl + '/api/brands';

  constructor(private http: HttpClient) {
  }

  getAlls(params: HttpParams): Observable<PaginatedResult<Brand>> {
    return this.http.get<PaginatedResult<Brand>>(this.baseUrl, {params: params});
  }

  getById(id: string) {
    return this.http.get<Brand>(this.baseUrl + id);
  }

  create(brand: Brand) {
    return this.http.post(this.baseUrl, brand);
  }

  update(brand: Brand) {
    return this.http.put(this.baseUrl, brand);
  }

  delete(id: string) {
    return this.http.delete(this.baseUrl + id);
  }
}
