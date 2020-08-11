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
  dicountedPrice: number;
  constructor() { }

  ngOnInit() {
  }
  calculatePrice(){
    if (this.product.discount > 0){
    this.dicountedPrice = (this.product.price / 100) * this.product.discount;
    return this.product.price - this.dicountedPrice;
    }
    return this.product.price;
  }

}
