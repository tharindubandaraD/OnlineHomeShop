import { AuthService } from './../../_services/auth.service';
import { Order } from './../../_models/order';
import { Cart } from './../../_models/cart';
import { CartService } from './../../_services/_cartservice/cart.service';
import { Category } from './../../_models/category';
import { AlertifyService } from './../../_services/alertify.service';
import { ProductService } from 'src/app/_services/product.service';
import { Product } from './../../_models/product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  category: Category;
  product: Product;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  cartComponentLoad = false;
  payment: any = {};
  discount: number;

  // tslint:disable-next-line: max-line-length
  constructor(private productService: ProductService, private alertify: AlertifyService,
              private route: ActivatedRoute, private cartService: CartService, private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.product = data['product'];
    });

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ];
      // tslint:disable-next-line: align
      this.galleryImages = this.getImages();

  }

  getImages() {
    const imageUrls = [];
    for (const photo of this.product.photos) {
      imageUrls.push({
        small: photo.url,
        medium: photo.url,
        big: photo.url,
        description: photo.description
      });
    }
    return imageUrls;
  }

  addToCart(){
    if (this.product.items == null)
    {
       this.product.items = 1;
    }
    if (this.cartService.addToCart(this.product)) {
          this.alertify.success(' product added to cart ');
    }
    else{
          this.alertify.error(' item already added  ');
    }
    // tslint:disable-next-line: quotemark
    // tslint:disable-next-line: max-line-length
    // const ordera: Order = { userId: this.authService.decodeToken.nameid, price: this.product.price, quantity: 1, productId: this.product.id};
    // this.cartService.postOrder(ordera).subscribe(() => {
    //      // tslint:disable-next-line: quotemark

    //       // tslint:disable-next-line: quotemark
    //       this.alertify.success("item added");
    //    }, error => {
    //       this.alertify.error(error);
    //       console.log(error());
    //    });
    // console.log(ordera);
  }

  makePurchase(){
    this.cartService.addToCart(this.product);
    if (this.product.items == null)
    {
       this.product.items = 1;
    }
    this.payment.totalPrice = this.product.price * this.product.items;
    this.discount = this.product.discount / 100;
    this.payment.discount = this.product.price * this.discount * this.product.items;
    this.payment.grandTotal = this.payment.totalPrice - this.payment.discount;

    this.cartService.paymentDetails(this.payment);
  }
}
