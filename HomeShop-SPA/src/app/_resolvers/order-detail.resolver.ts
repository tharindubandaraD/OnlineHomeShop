import { OrderService } from './../_services/_orderservice/orderservice.service';
import { ProductService } from 'src/app/_services/product.service';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/internal/operators/catchError';
import { Orderinformation } from '../_models/orderinformation';

@Injectable()
export class OrderDetailResolver implements Resolve<Orderinformation> {
    userId: number;
    constructor(private orderService: OrderService, private router: Router, private authService: AuthService,
                     // tslint:disable-next-line: align
                     private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Orderinformation> {
    this.userId = this.authService.decodeToken.nameid;
    return this.orderService.getOrderDetails(this.userId).pipe(
         catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['products']);
            return of(null);
         })
     );
  }
}
