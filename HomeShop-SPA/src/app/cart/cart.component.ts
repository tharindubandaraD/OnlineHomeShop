import { Product } from './../_models/product';
import { CartService } from './../_services/_cartservice/cart.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Component, OnInit } from '@angular/core';
import { Payment } from '../_models/payment';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  items: Product[];
  payment: any = {};

  constructor(private alertify: AlertifyService, private cartservice: CartService, private router: ActivatedRoute) { }

  ngOnInit() {
    //  this.router.data.subscribe( data => {
    //     // tslint:disable-next-line: no-string-literal
    //     this.cart = data['cart'];
    //  });
    this.items = this.cartservice.getItems();
  }

  gettotal(){
    let total = 0;

    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.items.length; i++){
         if (this.items[i].price) {
           total += this.items[i].price * this.items[i].items;
         }
     }
    return this.payment.totalPrice = total;
  }

  getdiscount(){
    let discount = 0;
    let amount = 0;
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.items.length; i++){
         if (this.items[i].discount > 0) {
           amount = this.items[i].discount / 100;
           discount += (this.items[i].price * this.items[i].items) * amount;
         }
       }
    return this.payment.discount = discount;
  }

  getgrandtotal(){
    return this.payment.grandTotal = this.gettotal() - this.getdiscount();
  }

  removeItem(Item: Product){
    this.cartservice.removeItems(Item.id);
    this.cartservice.getItems();
   // this.cartservice.removeItemFromCart(this.items.id);
    // console.log(Item.orderProductId);
    // this.alertify.confirm('Are you sure do you want to remove this product?', () => {
    //   this.cartservice.deleteOrderItem(Item.orderProductId).subscribe(() => {
    //     this.cart.splice(this.cart.findIndex(p => p.orderProductId === Item.orderProductId), 1);
    //     this.alertify.success('Product removed from cart');
    //   }, error => {
    //     this.alertify.error('Failed to remove item from cart');
    //   });
    // });

  }

  makePurchase(){
    this.cartservice.paymentDetails(this.payment);
  }

}
