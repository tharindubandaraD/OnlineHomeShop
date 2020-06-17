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
  constructor(private authservice: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authservice.register(this.registermodel).subscribe(() => {
      console.log('register successfully');
    }, error => {
      console.log(error);
    });
  }

  cancel(){
    this.registermode.emit(false);
  }

}
