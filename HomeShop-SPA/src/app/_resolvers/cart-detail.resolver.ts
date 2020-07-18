import { AlertifyService } from 'src/app/_services/alertify.service';
import { CartService } from './../_services/_cartservice/cart.service';
import { Observable, of } from 'rxjs';
import { AuthService } from './../_services/auth.service';
import { Cart } from './../_models/cart';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
@Injectable()
export class CartDetailResolver implements Resolve<Cart[]> {
    /**
     *
     */
    userId: number;
    constructor(private authservice: AuthService, private router: Router,
                private cartservice: CartService, private alertify: AlertifyService) { }


        resolve(route: ActivatedRouteSnapshot): Observable<Cart[]>{
        this.userId = this.authservice.decodeToken.nameid;
        return this.cartservice.getOrder(this.userId).pipe(
            catchError( error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['products']);
                return of(null);
            })
            );
    }
}
