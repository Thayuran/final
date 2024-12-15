import { Injectable } from '@angular/core';
import { Device } from '../_interface/inventory/device';
import { Result } from '../_interface/inventory/Result';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../_interface/inventory/PaginateResult';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductapiService {

  baseUrl = environment.apiUrl + '/api/devices';

  constructor(private http: HttpClient) {
  }

  getAlls(params: HttpParams): Observable<PaginatedResult<Device>>  {
    return this.http.get<PaginatedResult<Device>> (this.baseUrl, {params: params});
  }

  getById(id: string) {
    return this.http.get<Result<Device>>(this.baseUrl + id);
  }

  getImageById(id: string) {
    return this.http.get(this.baseUrl + `image/${id}`);
  }

  create(product: Device) {
    return this.http.post(this.baseUrl, product);
  }

  update(product: Device) {
    return this.http.put(this.baseUrl, product);
  }

  delete(id: string) {
    return this.http.delete(this.baseUrl + id);
  }
}
