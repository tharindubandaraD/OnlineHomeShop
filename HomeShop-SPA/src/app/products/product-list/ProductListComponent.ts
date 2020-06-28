import { AlertifyService } from './../../_services/alertify.service';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[];
  constructor(private productService: ProductService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts().subscribe((product: Product[]) => {
      this.products = product;
    },
      error => {
        this.alertify.error(error);
      });
  }

}
