import { Observable, of } from 'rxjs';
import { AlertifyService } from './../_services/alertify.service';
import { ProductService } from 'src/app/_services/product.service';
import { Category } from './../_models/category';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';

@Injectable()
export class CategoryListResolver implements Resolve<Category[]> {

    constructor(private productService: ProductService, private route: Router,
        // tslint:disable-next-line: align
        private alertify: AlertifyService){}

        resolve(route: ActivatedRouteSnapshot): Observable<Category[]> {
            return this.productService.getCategory().pipe(
                catchError(error => {
                   this.alertify.error('Problem retrieving data');
                   this.route.navigate(['home']);
                   return of(null);
                })
            );
        }
}
