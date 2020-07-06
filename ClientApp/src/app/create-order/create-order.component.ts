import { Component, OnInit } from '@angular/core';
import { OrderService } from '../service/order.service';
import { Order } from '../model/order';
import { v4 as uuidv4 } from 'uuid';
import { OrderDetail } from '../model/order-detail';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {
  customerName: string;
  feedback: string;
  products: Array<OrderDetail> = [
    { "Id": uuidv4(), "ProductId": uuidv4(), "ProductName": "Vino", Quantity: 2, Price: 5000 },
    { "Id": uuidv4(), "ProductId": uuidv4(), "ProductName": "Cervezas", Quantity: 1, Price: 2000 }
  ];

  constructor(private orderService: OrderService) { }

  ngOnInit() {
  }

  submit() {
    console.log("customer name: " + this.customerName);

    let order = new Order();
    order.Id = uuidv4();
    order.CreatedDate = new Date();
    order.CustomerId = uuidv4();
    order.CustomerName = this.customerName;
    order.Details = this.products;

    console.log("CreatedDate: " + order.CreatedDate);

    this.orderService.create(order).subscribe(result => {
      this.feedback = "OK";
      this.customerName = "";

      setTimeout(() => {
        this.feedback = "";
      }, 2000);

    }, (err) => {
        this.feedback = "ERROR";
        console.error(err);
    });
  }

}
