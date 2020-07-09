import { Category } from './../../_models/category';
import { AlertifyService } from './../../_services/alertify.service';
import { ProductService } from 'src/app/_services/product.service';
import { Product } from './../../_models/product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  category: Category;
  product: Product;

  constructor(private productService: ProductService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadProduct();
  }

  loadProduct() {
    // tslint:disable-next-line: no-string-literal
    this.productService.getProdct(+this.route.snapshot.params['id']).subscribe((product: Product) =>
    {
      this.product = product;
    }, error => {
      this.alertify.error(error);
    });
  }

}
