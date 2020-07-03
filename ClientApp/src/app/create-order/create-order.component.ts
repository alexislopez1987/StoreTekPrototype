import { Component, OnInit } from '@angular/core';
import { OrderService } from '../service/order.service';
import { Order } from '../model/order';

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
    order.Id = "c00407a3-95cb-44d8-a7f5-a16fcda88d99";
    order.CreatedDate = new Date();
    order.CustomerId = "37720147-8c2a-4133-b033-204ae90700ed";
    order.CustomerName = this.customerName;

    console.log("CreatedDate: " + order.CreatedDate);

    this.orderService.create(order).subscribe(result => {
      this.feedback = "OK";
      this.customerName = "";
    });
  }

}
