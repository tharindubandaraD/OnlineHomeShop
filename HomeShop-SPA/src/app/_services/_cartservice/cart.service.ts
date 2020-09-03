import { Payment } from './../../_models/payment';
import { Product } from './../../_models/product';
import { Order } from './../../_models/order';
import { Cart } from './../../_models/cart';
import { Observable, ReplaySubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  items = [];
  products: Product[];
  item: Product;
  productlist: Product[] = [];
    // tslint:disable-next-line: max-line-length
    // add replay subject - The ReplaySubject is comparable to the BehaviorSubject in the way that it can send “old” values to new subscribers
  cartSubject = new ReplaySubject<Product[]>();
  baseUrl = environment.apiUrl;
  checkout: Payment;

constructor(private http: HttpClient ) { }

// add card with replay subject - check local storage and update the value of observable
addToCart(productitem: Product): boolean {

  this.productlist = [];
  const localCartList = JSON.parse(localStorage.getItem('cart'));

  if (localCartList != null){
// tslint:disable-next-line: prefer-for-of
    for ( let i = 0; i < localCartList.length; i++) {
      this.productlist.push({
        id: localCartList[i].id,
        name: localCartList[i].name,
        price: localCartList[i].price,
        discount: localCartList[i].discount,
        photoUrl: localCartList[i].photoUrl,
        items: localCartList[i].items
       });
  }
  }
  if (!this.productlist.find(x => x.id === productitem.id)) {
        this.items.push(productitem);
        this.productlist.push({
          id: productitem.id,
          name: productitem.name,
          price: productitem.price,
          discount: productitem.discount,
          photoUrl: productitem.photoUrl,
          items: productitem.items
        });
        this.cartSubject.next(this.productlist);
        this.localStorageSet();
        // tslint:disable-next-line: no-angle-bracket-type-assertion

        return true;
  }
  return false;
}

// update cart even any request

updateCartState()
{
  this.productlist = [];
  const localCartList = JSON.parse(localStorage.getItem('cart'));
  if (localCartList != null){
    // tslint:disable-next-line: prefer-for-of
    for ( let i = 0; i < localCartList.length; i++) {
      this.productlist.push({
        id: localCartList[i].id,
        name: localCartList[i].name,
        price: localCartList[i].price,
        discount: localCartList[i].discount,
        photoUrl: localCartList[i].photoUrl,
        items: localCartList[i].items
       });
  }
    this.cartSubject.next(this.productlist);
}
}

// clean items same time in observable and local storage

cleanCart() {
  this.productlist = [];
  this.cartSubject.next(this.productlist);
  this.localStorageSet();
}

// get one method to set item in local storage due  to repeating this pice of code in may place

localStorageSet(){
  localStorage.setItem('cart', JSON.stringify(this.productlist));
}

paymentDetails(payment: Payment) {
   this.checkout = payment;
}

getPaymentDetails() {
  return this.checkout;
}

removeItems(id: number) {
  this.productlist.splice(this.productlist.findIndex(x => x.id === id), 1);
  // tslint:disable-next-line: no-angle-bracket-type-assertion
  this.cartSubject.next(this.productlist );
  this.localStorageSet();
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
