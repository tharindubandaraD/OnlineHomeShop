import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CategoryListResolver } from './_resolvers/category-list.resolver';
import { ProductDetailResolver } from './_resolvers/product-detail.resolver';
import { AuthGuard } from './_guards/auth.guard';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { appRouters } from './routes';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import {NgbPaginationModule, NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { from } from 'rxjs';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MessagesComponent } from './messages/messages.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { CartComponent } from './cart/cart.component';
import { Product_cardComponent } from './products/product_card/product_card.component';
import { CartDetailResolver } from './_resolvers/cart-detail.resolver';
import { PaymentComponent } from './payment/payment.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrderDetailResolver } from './_resolvers/order-detail.resolver';
import { ReportComponent } from './report/report.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      ProductListComponent,
      Product_cardComponent,
      ProductDetailComponent,
      CartComponent,
      MessagesComponent,
      PaymentComponent,
      ReportComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      NgxGalleryModule,
      FormsModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRouters),
      JwtModule.forRoot({
         config: {
            // tslint:disable-next-line: object-literal-shorthand
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      }),
      NgbModule,
      NgbPaginationModule,
      NgbAlertModule
   ],
   providers: [
      ErrorInterceptorProvider,
      AuthGuard,
      ProductDetailResolver,
      CategoryListResolver,
      CartDetailResolver,
      UserDetailResolver,
      OrderDetailResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
