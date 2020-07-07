import { Component, OnInit } from '@angular/core';
import { OrderService } from '../service/order.service';

@Component({
  selector: 'app-get-orders',
  templateUrl: './get-orders.component.html',
  styleUrls: ['./get-orders.component.css']
})
export class GetOrdersComponent implements OnInit {

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService.getOrders().subscribe((data) => {
      console.log("ordenes: ");
      console.log(data);
    }, (err) => {
        console.error("error al obtener ordenes");
        console.error(err);
    });
  }
}
