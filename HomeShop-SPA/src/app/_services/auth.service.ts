import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private JwtHelper = new JwtHelperService();
  private baseUrl = environment.apiUrl + 'auth/';
  decodeToken: any;

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post(this.baseUrl + 'login' , model)
            .pipe(
              map( (res: any) => {
                const user = res;
                if (user) {
                    localStorage.setItem('token', user.token);
                    this.decodeToken = this.JwtHelper.decodeToken(user.token);
                  }
              })
            );
  }

  register(model: any) {
    return this.http.post( this.baseUrl + 'register', model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.JwtHelper.isTokenExpired(token);
  }
}
