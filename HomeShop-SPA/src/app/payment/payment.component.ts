import { UserService } from './../_services/_user/user.service';
import { AlertifyService } from './../_services/alertify.service';
import { PaymentService } from './../_services/_payment/payment.service';
import { Payment } from 'src/app/_models/payment';
import { Product } from 'src/app/_models/product';
import { CartService } from './../_services/_cartservice/cart.service';
import { Component, OnInit } from '@angular/core';
import { OrderPayment } from '../_models/orderpayment';
import { AuthService } from '../_services/auth.service';
import { UserDetails } from '../_models/userDetails';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  payment: Payment;
  items: Product[];
  orderPayment: any = {};
  userDetail: UserDetails;


  // tslint:disable-next-line: max-line-length
  constructor(private userservice: UserService, private authService: AuthService, private cartService: CartService, private paymentService: PaymentService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
   this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.userDetail = data['userDetails'];
    });
   this.payment = this.cartService.getPaymentDetails();
   this.items = this.cartService.getItems();
  }
  assignValue(): OrderPayment {

    this.orderPayment.userId = this.authService.decodeToken.nameid;
    this.orderPayment.discount = this.payment.discount;
    this.orderPayment.fullName = this.userDetail.fullName;
    this.orderPayment.address = this.userDetail.address;
    this.orderPayment.grandTotal = this.payment.grandTotal;
    this.orderPayment.total = this.payment.totalPrice;
    this.orderPayment.email = this.userDetail.email;
    this.orderPayment.OrderProductDto = this.items;
    return this.orderPayment;

  }
  makepayment(){
    this.assignValue();
    this.paymentService.postPayment(this.assignValue()).subscribe(() => {
      this.alertify.success('payment done successfully');
    },
    error => {
      this.alertify.error('error on this');
    });
    this.cartService.cleanCart();
  }
}
