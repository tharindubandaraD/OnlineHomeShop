import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { element } from 'protractor';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() registermode = new EventEmitter();

  registermodel: any = {};
  constructor(private authservice: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authservice.register(this.registermodel).subscribe(() => {
        this.alertify.success('register successfully');
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel(){
    this.registermode.emit(false);
  }

}
