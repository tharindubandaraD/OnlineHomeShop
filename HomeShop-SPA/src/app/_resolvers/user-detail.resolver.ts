import { UserService } from './../_services/_user/user.service';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { AlertifyService } from './../_services/alertify.service';
import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserDetails } from '../_models/userDetails';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class UserDetailResolver implements Resolve<UserDetails> {
    userId: number;
       constructor(private userService: UserService, private router: Router, private authService: AuthService,
                        // tslint:disable-next-line: align
                        private alertify: AlertifyService) {}

     resolve(route: ActivatedRouteSnapshot): Observable<UserDetails> {
        this.userId = this.authService.decodeToken.nameid;
        return this.userService.getUser(this.userId).pipe(
             catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['products']);
                return of(null);
             })
         );
     }
}
