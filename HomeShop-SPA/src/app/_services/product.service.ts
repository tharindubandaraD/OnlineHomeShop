import { Product } from 'src/app/_models/product';
import { Category } from './../_models/category';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
  return this.http.get<Product[]>(this.baseUrl + 'product');
  }

  getProdct(id): Observable<Product>{
  return this.http.get<Product>(this.baseUrl + 'product/' + id);
  }
  getCategory(): Observable<Category[]>{
    return this.http.get<Category[]>(this.baseUrl + 'category');
  }

  getProductstoCategory(id): Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl + 'product/category/' + id.categotyId);
  }


}
