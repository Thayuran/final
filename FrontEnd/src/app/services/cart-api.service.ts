import { Injectable } from '@angular/core';
import { CartItemApiModel } from '../_interface/inventory/cartitemApi';
import { Result } from '../_interface/inventory/Result';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CartApiService {

  baseUrl = environment.apiUrl + '/carts/';

  constructor(private http: HttpClient) {
  }
  create(customerId: string) {
    return this.http.post<Result<string>>(this.baseUrl, { "customerId": customerId });
  }
  get(customerId: string) {
    let params = new HttpParams();
    params = params.append('customerId', customerId);
    return this.http.get<Result<CartItemApiModel[]>>(this.baseUrl, { params: params });
  }
  clear(cartId: string)
  {
    return this.http.delete<Result<string>>(this.baseUrl + 'clear/' + cartId);
  }
}
