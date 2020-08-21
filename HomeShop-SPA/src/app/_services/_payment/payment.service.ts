import { OrderPayment } from './../../_models/orderPayment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

postPayment(orderPayment: OrderPayment){
  return this.http.post(this.baseUrl + 'order', orderPayment);
}
}
