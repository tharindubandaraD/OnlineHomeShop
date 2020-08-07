import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  images = ['https://cdn.dnaindia.com/sites/default/files/styles/full/public/2019/03/13/801559-pubg-03.jpg', 'https://lite.pubg.com/wp-content/uploads/2019/10/image-5-1499x625.jpg', 'https://lite.pubg.com/wp-content/uploads/2019/10/image-5-1499x625.jpg'];
  registerMode = false;
  constructor() { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerMode = true;
    console.log(this.registerMode);
  }

  registerState(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
