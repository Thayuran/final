import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../_interface/inventory/category';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../_interface/inventory/PaginateResult';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CategoryapiService {

  baseUrl = environment.apiUrl + '/api/categories';

  constructor(private http: HttpClient) {
  }

  getAlls(params: HttpParams): Observable<PaginatedResult<Category>>  {
    return this.http.get<PaginatedResult<Category>> (this.baseUrl, {params: params});
  }

  getById(id: string) {
    return this.http.get<Category>(this.baseUrl + id);
  }

  create(category: Category) {
    return this.http.post(this.baseUrl, category);
  }

  update(category: Category) {
    return this.http.put(this.baseUrl, category);
  }

  delete(id: string) {
    return this.http.delete(this.baseUrl + id);
  }
}
