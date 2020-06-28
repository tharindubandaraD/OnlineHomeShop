import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Product } from '../_models/product';

const httpOptions = {
  headers: new HttpHeaders({
    // tslint:disable-next-line: object-literal-key-quotes
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }

getProducts(): Observable<Product[]> {
  return this.http.get<Product[]>(this.baseUrl + 'product', httpOptions);
}

getProdct(id): Observable<Product>{
  return this.http.get<Product>(this.baseUrl + 'product' + id, httpOptions);
}

}
