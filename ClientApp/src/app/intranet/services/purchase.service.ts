import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";
import {HttpClient} from "@angular/common/http";

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

  purchase(addressId: string) {
    return this.http.get(`${this.apiUrl}address/${addressId}/purchase`);
  }

  returnOrder(orderId: string, detailId: string) {
    return this.http.get(`${this.apiUrl}${orderId}/purchases/${detailId}/return`);
  }
}
