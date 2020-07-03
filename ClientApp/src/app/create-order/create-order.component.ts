import { Component, OnInit } from '@angular/core';
import { OrderService } from '../service/order.service';
import { Order } from '../model/order';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {
  customerName: string;
  feedback: string;

  constructor(private orderService: OrderService) { }

  ngOnInit() {
  }

  submit() {
    console.log("customer name: " + this.customerName);

    const order = new Order();
    order.Id = uuidv4();
    order.CreatedDate = new Date();
    order.CustomerId = uuidv4();
    order.CustomerName = this.customerName;

    console.log("CreatedDate: " + order.CreatedDate);

    this.orderService.create(order).subscribe(result => {
      this.feedback = "OK";
      this.customerName = "";

      setTimeout(() => {
        this.feedback = "";
      }, 2000);

    });
  }

}
