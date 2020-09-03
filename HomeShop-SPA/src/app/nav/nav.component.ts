import { CartService } from './../_services/_cartservice/cart.service';
import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Product } from '../_models/product';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  item: any = {};
  model: any = {};
  private subscription: Subscription;
  // tslint:disable-next-line: max-line-length
  constructor(private cartService: CartService, public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.cartService.updateCartState();
    this.subscription = this.cartService.cartSubject
                     .subscribe((product: Product[]) => {
                         this.item = product;
                     });
  }

   // tslint:disable-next-line: use-lifecycle-interface
   ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  login() {
    this.authService.login(this.model).subscribe ( next => {
      this.alertify.success('Loggin successfully');
    },
      error => {
        this.alertify.error('error in loggin');
      }, () => {
        this.router.navigate(['/products']);
      }
    );
  }

  loggedIn() {
    // const token = localStorage.getItem('token');
    // if this has something then it return true
    // return !!token;
    return this.authService.loggedIn();
  }

  loggedOut() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }
}
