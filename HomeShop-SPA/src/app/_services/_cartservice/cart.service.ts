import { Cart } from './../../_models/cart';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseUrl = environment.apiUrl;

constructor(private http: HttpClient ) { }

postOrder(model: any){
  return this.http.post(this.baseUrl + 'order', model);
}

getOrder(id): Observable<Cart[]>{
   return this.http.get<Cart[]>(this.baseUrl + 'order/' + id);
}

}
