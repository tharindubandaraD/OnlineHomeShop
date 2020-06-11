import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  values: any;
  value: any;
  id: number;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getvalue();
  }

  getValues() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
  }
  getvalue() {
    this.id = 2;
    this.http.get('http://localhost:5000/api/values/' + this.id).subscribe(response => {
      this.value = response;
  }, error => {
    console.log(error);
  });
  }
}
