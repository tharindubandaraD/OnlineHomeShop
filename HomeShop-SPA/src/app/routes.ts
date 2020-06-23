import { AuthGuard } from './_guards/auth.guard';
import { CartComponent } from './cart/cart.component';
import { MessagesComponent } from './messages/messages.component';
import { ProductListComponent } from './product-list/product-list.component';
import { HomeComponent } from './home/home.component';
import {Routes} from '@angular/router';
import { ProductComponent } from './product/product.component';

export const appRouters: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'products', component: ProductListComponent},
            {path: 'product', component: ProductComponent},
            {path: 'cart', component: CartComponent },
            {path: 'message', component: MessagesComponent},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
