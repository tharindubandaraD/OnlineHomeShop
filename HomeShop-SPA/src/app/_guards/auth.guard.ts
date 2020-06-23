import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authservice: AuthService, private alertify: AlertifyService, private route: Router){}
  canActivate(): boolean{
    if (this.authservice.loggedIn())
    {
      return true;
    }
    this.alertify.error('cannot access..!!');
    this.route.navigate(['/home']);
    return false;
  }
}
