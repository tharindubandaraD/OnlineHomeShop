import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Token } from '@angular/compiler/src/ml_parser/lexer';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'HomeShop-SPA';
  private JwtHelper = new JwtHelperService();

  constructor(public authService: AuthService, ) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
        this.authService.decodeToken = this.JwtHelper.decodeToken(token);
    }
  }

}
