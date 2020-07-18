import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Component, OnInit } from '@angular/core';
import { Cart } from '../_models/cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: Cart[];

  constructor(private alertify: AlertifyService, private router: ActivatedRoute) { }

  ngOnInit() {
     this.router.data.subscribe( data => {
        // tslint:disable-next-line: no-string-literal
        this.cart = data['cart'];
     });
  }

  // getCart(){
  //   this.userId = this.authservice.decodeToken.nameid;
  //   this.cartservice.getOrder(this.userId).subscribe((cart: Cart[]) =>
  //   {
  //     this.cart = cart;
  //     console.log(cart);
  //   },
  //   error => {
  //     this.alertify.error(error);
  //   });
  // }

}
