import { Category } from './../../_models/category';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[];
  category: Category[];
  num: number;
  constructor(private productService: ProductService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadCategory();
  }

  loadProducts(cat: Category) {
    this.num = 1;
    console.log(cat);
    this.productService.getProductstoCategory(cat).subscribe((product: Product[]) => {
      this.products = product;
    },
    error => {
      this.alertify.error(error);
    });
  }


  loadCategory() {
    this.productService.getCategory().subscribe((category: Category[]) => {
      this.category = category;
    },
    error => {
      this.alertify.error(error);
    });
  }
}
