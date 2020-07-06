import { OrderDetail } from "./order-detail";

export class Order {
  Id: string;
  CreatedDate: Date;
  CustomerId: string;
  CustomerName: string;
  Details: Array<OrderDetail>
}
