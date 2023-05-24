import { Component } from '@angular/core';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.scss']
})
export class MyOrdersComponent {
  orderData: any = [
    {
      name: 'Product 1',
      id: 1,
      price: 100,
      status: false,
      description: false,
    } 
  ];
  constructor() { }

  ngOnInit(): void {
    this.getOrderList()
  }
  cancelOrder(orderId: number | undefined) {
    
  }
  getOrderList() {
  }
}
