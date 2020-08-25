import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  images = ['./assets/img-1.png', './assets/img-2.png', './assets/img-3.png'];
  registerMode = false;
  constructor() { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerMode = true;
  }

  registerState(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
