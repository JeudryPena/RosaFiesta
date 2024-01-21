import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";
import {HttpClient} from "@angular/common/http";
import {OrderDto} from "@core/interfaces/Product/UserInteract/orderDto";

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  private apiUrl = `${config.apiURL}purchase/`

  constructor(
    private http: HttpClient
  ) {
  }

  retrieveUserOrders() {
    return this.http.get(`${this.apiUrl}myOrders`);
  }

  purchase(orderDto: OrderDto) {
    return this.http.post(`${this.apiUrl}purchase`, orderDto);
  }

  returnOrder(orderId: string, detailId: string) {
    return this.http.get(`${this.apiUrl}${orderId}/purchases/${detailId}/return`);
  }

  createOrder(data: any) {
    return this.http.post(`${this.apiUrl}create-order`, data);
  }
}
