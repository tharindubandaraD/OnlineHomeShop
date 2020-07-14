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
      MessagesComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BrowserAnimationsModule,
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
      })
   ],
   providers: [
      ErrorInterceptorProvider,
      AuthGuard,
      ProductDetailResolver,
      CategoryListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
