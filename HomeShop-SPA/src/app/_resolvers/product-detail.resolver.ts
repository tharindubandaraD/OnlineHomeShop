import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { AlertifyService } from './../_services/alertify.service';
import { ProductService } from 'src/app/_services/product.service';
import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Product } from '../_models/product';

@Injectable()
export class ProductDetailResolver implements Resolve<Product> {
       constructor(private productService: ProductService, private router: Router,
                        // tslint:disable-next-line: align
                        private alertify: AlertifyService) {}

     resolve(route: ActivatedRouteSnapshot): Observable<Product> {
         // tslint:disable-next-line: no-string-literal
         return this.productService.getProdct(route.params['id']).pipe(
             catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['products']);
                return of(null);
             })
         );
     }
}
