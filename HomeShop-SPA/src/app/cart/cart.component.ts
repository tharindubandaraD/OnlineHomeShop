import { CartService } from './../_services/_cartservice/cart.service';
import { Cart } from './../_models/cart';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Component, OnInit } from '@angular/core';
import { state } from '@angular/animations';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: Cart[];
  quantity: number[];

  constructor(private alertify: AlertifyService, private cartservice: CartService, private router: ActivatedRoute) { }

  ngOnInit() {
     this.router.data.subscribe( data => {
        // tslint:disable-next-line: no-string-literal
        this.cart = data['cart'];
     });
     console.log(this.cart);
  }

  gettotal(){
    let total = 0;
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.cart.length; i++){
        if (this.cart[i].price) {
          total += this.cart[i].price * this.cart[i].quantity;
        }
      }
    return total;
  }

  getdiscount(){
    let discount = 0;
    let amount = 0;
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.cart.length; i++){
        if (this.cart[i].discount > 0) {
          amount = this.cart[i].discount / 100;
          discount += (this.cart[i].price * this.cart[i].quantity) * amount;
        }
      }
    return discount;
  }

  getgrandtotal(){
    return this.gettotal() - this.getdiscount();
  }
  removeItem(Item: Cart){
    console.log(Item.orderProductId);
    this.alertify.confirm('Are you sure do you want to remove this product?', () => {
      this.cartservice.deleteOrderItem(Item.orderProductId).subscribe(() => {
        this.cart.splice(this.cart.findIndex(p => p.orderProductId === Item.orderProductId), 1);
        this.alertify.success('Product removed from cart');
      }, error => {
        this.alertify.error('Failed to remove item from cart');
      });
    });

  }

}
