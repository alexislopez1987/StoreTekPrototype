import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../model/order';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  url: string = "https://localhost:44395/api/Order";

  constructor(private http: HttpClient) { }

  create(order: Order) {
    return this.http.post(this.url, {
      "Id": order.Id,
      "CreatedDate": order.CreatedDate,
      "CustomerId": order.CustomerId,
      "CustomerName": order.CustomerName
    }).pipe(
      map((res: any) => {
        return res;
      })
    );
  }
}
