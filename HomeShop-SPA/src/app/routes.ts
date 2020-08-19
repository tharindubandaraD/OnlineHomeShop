import { ReportComponent } from './report/report.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { PaymentComponent } from './payment/payment.component';
import { ProductDetailResolver } from './_resolvers/product-detail.resolver';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { AuthGuard } from './_guards/auth.guard';
import { CartComponent } from './cart/cart.component';
import { MessagesComponent } from './messages/messages.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { HomeComponent } from './home/home.component';
import {Routes} from '@angular/router';
import { CategoryListResolver } from './_resolvers/category-list.resolver';
import { CartDetailResolver } from './_resolvers/cart-detail.resolver';
import { OrderDetailResolver } from './_resolvers/order-detail.resolver';

export const appRouters: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'products', component: ProductListComponent, resolve: {category: CategoryListResolver}},

            {path: 'products/:id', component: ProductDetailComponent,  resolve: {product: ProductDetailResolver}},

            {path: 'cart', component: CartComponent, resolve: {cart: CartDetailResolver}},

            {path: 'message', component: MessagesComponent},

            {path: 'payment', component: PaymentComponent, resolve: {userDetails: UserDetailResolver}},

            {path: 'report', component: ReportComponent, resolve: {orderDetails: OrderDetailResolver}}

        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
