import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { CartItemApiModel } from 'src/app/_interface/inventory/cartitemApi';
import { Device } from 'src/app/_interface/inventory/device';
import { CartItem } from 'src/app/models/carts';
import { CartItemApiService } from 'src/app/services/cart-item-api.service';
import { environment } from 'src/environments/environment.development';



@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

 private cartItems$ = new Subject<CartItem[]>();
  private cartItems: CartItem[] = [];

  public cartId: string;
  public isCartLoading: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isCartInvalid: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
  public IsProductBeingAdded: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);


  constructor(private http: HttpClient,private cartItemApi: CartItemApiService,private toastr:ToastrService) { }

  public getData = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, environment.apiUrl));
  }

  public create = (route: string, body:any) => {
    return this.http.post(this.createCompleteRoute(route, environment.apiUrl), body, this.generateHeaders());
  }
  public createWithData = (route: string) => {
    return this.http.post(this.createCompleteRoute(route, environment.apiUrl), this.generateHeaders());
  }
  public update = (route: string, body:any) => {
    return this.http.put(this.createCompleteRoute(route, environment.apiUrl), body, this.generateHeaders());
  }

  public delete = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, environment.apiUrl));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
  }

 
 add(product: Device, quantity: number = 1) {
  console.log(product);
    //if (!this.cartId) { return; }
    this.IsProductBeingAdded.next(true);
    var foundItem = this.cartItems.find(a => a.productId == product.id);
console.log(foundItem);
    if (foundItem) {
      foundItem.quantity = foundItem.quantity + quantity;
      this.updateCart(foundItem.id, foundItem.productId, foundItem.quantity);
    }
    else {
      this.cartItems.push(new CartItem(product.id, quantity ?? 1, product.name, product.serialNumber, product.price));
      const cartItem = new CartItemApiModel(product.name, quantity??1);
      this.cartItemApi.create(cartItem).subscribe((res) => {
        if (res && res.succeeded) {
          this.toastr.info(res.messages[0], '', {
            positionClass: 'toast-top-right'
          });
          var foundItem = this.cartItems.find(a => a.productId == product.id);
          if (foundItem) {
            foundItem.id = res.data;
          }
        }
      }).add(()=>this.IsProductBeingAdded.next(false));
    }
    this.cartItems$.next(this.calculate(this.cartItems));
  }


  private updateCart(cartItemId: string, productId: string, quantity: number) {
    this.IsProductBeingAdded.next(true);
    var cartItem = new CartItemApiModel(productId, quantity);
    cartItem.id = cartItemId;
    this.cartItemApi.update(cartItem).subscribe((res) => this.toastr.info(res.messages[0], '', {
      positionClass: 'toast-top-right'
    })).add(() => this.IsProductBeingAdded.next(false));
  }

  private calculate(cartItems: CartItem[]): CartItem[] {
    cartItems.forEach(function (part, index, theArray) {
      theArray[index].total = cartItems[index].quantity * cartItems[index].price;
    });
    return cartItems;
  }


  loadCurrentCart(): CartItem[] {
    return this.calculate(this.cartItems);
  }


  get(): Observable<CartItem[]> {
      return this.cartItems$.asObservable();
    }

    
}
