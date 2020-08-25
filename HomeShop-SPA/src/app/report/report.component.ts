import { OrderService } from './../_services/_orderservice/orderservice.service';
import { OrderDetail } from './../_models/orderDetail';
import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {
  orderDetails: any[];
  pageOrderDetails: any[];
  orderProductDetail: any[];
  page = 1;
  pageSize = 8;

  constructor( private alertify: AlertifyService, private route: ActivatedRoute, private orderService: OrderService) {  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.orderDetails = data['orderDetails'];
    });
    this.refreshData();
  }

  refreshData() {
    this.pageOrderDetails = this.orderDetails
      .map((items, i) => ({id: i + 1, items}))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
    }

    viewExpand(expand: boolean , orderid: number )
    {
      if (expand){
        this.orderService.getOrderProductDetails(orderid).subscribe(
          res => {
            this.orderProductDetail = res;
          }, error => {
            this.alertify.error('problem retrieving with data');
          });
      }
      else{
        console.log(orderid);
      }
    }
}
