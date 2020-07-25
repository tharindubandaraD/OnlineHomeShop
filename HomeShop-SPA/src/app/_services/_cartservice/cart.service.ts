import { Payment } from './../../_models/payment';
import { Product } from './../../_models/product';
import { Order } from './../../_models/order';
import { Cart } from './../../_models/cart';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  items = [];
  baseUrl = environment.apiUrl;
  checkout: Payment;
constructor(private http: HttpClient ) { }

addToCart(productitem: Product): boolean {
  // tslint:disable-next-line: whitespace
  if(!this.items.find(x => x.id === productitem.id)) {
        this.items.push(productitem);
        return true;
  }
  return false;
}

getItems() {
  return this.items;
}

cleanCart() {
  this.items = [];
  return this.items;
}

paymentDetails(payment: Payment) {
   this.checkout = payment;
}

getPaymentDetails() {
  return this.checkout;
}

removeItems(id: number) {
  this.items.splice(this.items.findIndex(x => x.id === id), 1);
}

 postOrder(model: any){
   return this.http.post(this.baseUrl + 'order', model);
 }

 getOrder(id): Observable<Cart[]>{
    return this.http.get<Cart[]>(this.baseUrl + 'order/' + id);
 }

 deleteOrderItem(id: number){
   return this.http.delete(this.baseUrl + 'order/' + id);
 }

}
