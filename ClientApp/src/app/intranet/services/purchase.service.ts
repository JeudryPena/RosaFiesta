import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";
import {HttpClient} from "@angular/common/http";
import {OrderDto} from "@core/interfaces/Product/UserInteract/orderDto";
import {OrderPreviewResponse} from "@core/interfaces/Product/Response/orderPreviewResponse";
import {Observable} from "rxjs";
import {OrderResponse} from "@core/interfaces/Product/UserInteract/Response/orderResponse";
import {OrderManagementPreviewResponse} from "@core/interfaces/Product/Response/OrderManagementPreviewResponse";
import {
  AnalyticDataResponse,
  MostPurchasedProductsResponse,
  MostPurchasedProductsWithDateResponse,
  OrderComparativeResponse
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

  getLatLngByZipcode(zipcode: string) {
    return this.http.get(`https://maps.googleapis.com/maps/api/geocode/json?address=${zipcode}&region=DO&key=${config.googleMapsApiKey}`);
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

  retrieveOrderComparative(start: string, end: string): Observable<OrderComparativeResponse> {
    return this.http.get<OrderComparativeResponse>(`${this.apiUrl}order-comparative/${start}/${end}`);
  }

  retrieveAnalyticData(start: string, end: string): Observable<AnalyticDataResponse> {
    return this.http.get<AnalyticDataResponse>(`${this.apiUrl}analytic-data/${start}/${end}`);
  }

  oficializeReturn(orderId: string) {
    return this.http.get(`${this.apiUrl}${orderId}/oficialize-return`);
  }

  rejectReturn(orderId: string) {
    return this.http.get(`${this.apiUrl}${orderId}/reject-return`);
  }
}
