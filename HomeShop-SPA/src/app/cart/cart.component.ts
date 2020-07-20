import { Cart } from './../_models/cart';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: Cart[];
  quantity: number[];

  constructor(private alertify: AlertifyService, private router: ActivatedRoute) { }

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

  removeItem(removeItem: Cart){
    console.log(removeItem);
  }

}
