import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";
import {HttpClient} from "@angular/common/http";
import {OrderDto} from "@core/interfaces/Product/UserInteract/orderDto";
import {OrderPreviewResponse} from "@core/interfaces/Product/Response/orderPreviewResponse";
import {Observable} from "rxjs";
import {OrderResponse} from "@core/interfaces/Product/UserInteract/Response/orderResponse";
import {OrderManagementPreviewResponse} from "@core/interfaces/Product/Response/OrderManagementPreviewResponse";
import {
  MostPurchasedProductsResponse,
  MostPurchasedProductsWithDateResponse
} from "@core/interfaces/Product/Response/MostPurchasedProductsResponse";

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  private apiUrl = `${config.apiURL}purchase/`

  constructor(
    private http: HttpClient
  ) {
  }

  retrieveAllOrders(take: number = 0): Observable<OrderManagementPreviewResponse[]> {
    return this.http.get<OrderManagementPreviewResponse[]>(`${this.apiUrl}orders/${take}`);
  }

  purchase(orderDto: OrderDto) {
    return this.http.post(`${this.apiUrl}purchase`, orderDto);
  }

  requestRefund(id: string): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}${id}/return`);
  }

  createOrder(data: any) {
    return this.http.post(`${this.apiUrl}create-order`, data);
  }

  retrieveMyOrders(): Observable<OrderPreviewResponse[]> {
    return this.http.get<OrderPreviewResponse[]>(`${this.apiUrl}myOrders`);
  }

  retrieveOrderDetail(id: string): Observable<OrderResponse> {
    return this.http.get<OrderResponse>(`${this.apiUrl}${id}/detail`);
  }

  retrieveCountOrders(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}count`);
  }

  retrieveGains(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}gains`);
  }

  retrieveMostPurchasedProducts(): Observable<MostPurchasedProductsResponse[]> {
    return this.http.get<MostPurchasedProductsResponse[]>(`${this.apiUrl}most-purchased-products`);
  }

  retrieveMostPurchasedProductsWithDates(start: string, end: string): Observable<MostPurchasedProductsWithDateResponse[]> {
    return this.http.get<MostPurchasedProductsWithDateResponse[]>(`${this.apiUrl}most-purchased-products/${start}/${end}`);
  }
}
