import { Injectable } from '@angular/core';
import { Result } from '../_interface/inventory/Result';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { CartItem } from '../_interface/inventory/cartitem';

@Injectable({
  providedIn: 'root'
})
export class CartItemApiService {

  baseUrl = environment.apiUrl + '/Sales';
  constructor(private http: HttpClient) {
  }
  // get(cartId: string) {
  //   let params = new HttpParams();
  //   params = params.append('/id', cartId);
  //   return this.http.get<Result<CartItemApiModel[]>>(this.baseUrl, { params: params });
  // }
  // create(cartItem: CartItemApiModel) {
  //   return this.http.post<Result<string>>(this.baseUrl, cartItem);
  // }

  // update(cartItem: CartItemApiModel) {
  //   return this.http.put<Result<string>>(this.baseUrl, cartItem);
  // }
  // delete(id: string) {
  //   return this.http.delete<Result<string>>(this.baseUrl + id);
  // }

  get(id: string) {
      return this.http.get<CartItem>(this.baseUrl + id);
    }

    create(item: CartItem) {
      return this.http.post<Result<string>>(this.baseUrl, item);
    }

    update(item: CartItem) {
      return this.http.put<Result<string>>(this.baseUrl, item);
    }

    delete(id: string) {
      return this.http.delete<Result<string>>(this.baseUrl + id);
    }
}
