import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
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
    console.log('logged out');
    this.router.navigate(['/home']);
  }
}
