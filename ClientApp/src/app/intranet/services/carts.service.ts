import {Injectable} from '@angular/core';
import {config} from "../../../env/config.prod";
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {CartResponse} from '../../core/interfaces/Product/Response/cartResponse';
import {PurchaseDetailDto} from '../../core/interfaces/Product/UserInteract/purchaseDetailDto';

@Injectable({
  providedIn: 'root'
})
export class CartsService {
  private apiUrl = `${config.apiURL}carts/`
  private cart: BehaviorSubject<any> =
    new BehaviorSubject<any>(null);

  constructor(
    private http: HttpClient
  ) {
  }

  get getCart$() {
    return this.cart.asObservable();
  }

  updatedCart() {
    this.cart.next(true);
  }

  verifyStock(detailId: string, optionId: string, quantity: number) {
    return this.http.get(`${this.apiUrl}detail/${detailId}/option/${optionId}/quantity/${quantity}`);
  }

  getMyCart(): Observable<CartResponse> {
    return this.http.get<CartResponse>(`${this.apiUrl}myCart`);
  }

  AddProductToCart(cartItem: PurchaseDetailDto): Observable<CartResponse> {
    return this.http.put<CartResponse>(`${this.apiUrl}addProductToCart`, cartItem);
  }

  UpdateQuantity(quantity: number, detailId: string, optionId: string) {
    return this.http.get(`${this.apiUrl}detail/${detailId}/option/${optionId}/adjust/${quantity}`);
  }

  RemoveItem(detailId: string, optionId: string) {
    return this.http.delete(`${this.apiUrl}detail/${detailId}/option/${optionId}/remove`);
  }

  ClearCart() {
    return this.http.delete(`${this.apiUrl}clear`);
  }
}
