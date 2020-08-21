import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Orderinformation } from 'src/app/_models/orderinformation';
import { Orderinformationproduct } from 'src/app/_models/orderinformationproduct';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

 baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }

getOrderDetails(id): Observable<Orderinformation[]>{
  return this.http.get<Orderinformation[]>(this.baseUrl + 'order/orderinformation/' + id);
}

getOrderProductDetails(id): Observable<Orderinformationproduct[]>{
  return this.http.get<Orderinformationproduct[]>(this.baseUrl + 'order/orderinformationproduct/' + id);
}

}
