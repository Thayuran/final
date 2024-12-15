import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Result } from '../_interface/inventory/Result';
import { Employee } from '../_interface/inventory/employee';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../_interface/inventory/PaginateResult';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CustomerapiService {

  baseUrl = environment.apiUrl + '/api/customers';

  constructor(private http: HttpClient) {
  }

  // getAlls(params:HttpParams) {
  //   return this.http.get(this.baseUrl, {params: params});
  // }
  getAlls(params: HttpParams): Observable<PaginatedResult<Employee>> {
    return this.http.get<PaginatedResult<Employee>>(this.baseUrl, { params });
  }

  getById(id: string): Observable<Result<Employee>> {
    return this.http.get<Result<Employee>>(this.baseUrl + `/${id}`);
  }

  create(customer: Employee) {
    return this.http.post(this.baseUrl, customer);
  }

  update(customer: Employee) {
    return this.http.put(this.baseUrl, customer);
  }

  delete(id: string) {
    return this.http.delete(this.baseUrl + `/${id}`);
  }
}

