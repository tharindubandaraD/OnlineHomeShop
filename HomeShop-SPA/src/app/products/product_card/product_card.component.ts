import { Product } from './../../_models/product';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-product_card',
  templateUrl: './product_card.component.html',
  styleUrls: ['./product_card.component.css']
})
// tslint:disable-next-line: class-name
export class Product_cardComponent implements OnInit {
  @Input() product: Product;

  constructor() { }

  ngOnInit() {
  }

}
