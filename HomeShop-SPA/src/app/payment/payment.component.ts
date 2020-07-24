import { Payment } from 'src/app/_models/payment';
import { Product } from 'src/app/_models/product';
import { CartService } from './../_services/_cartservice/cart.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  payment: Payment;
  items: Product[];

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.payment = this.cartService.getPaymentDetails();
    this.items = this.cartService.getItems();
  }

}
