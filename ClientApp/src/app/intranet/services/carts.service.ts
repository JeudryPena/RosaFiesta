import { Injectable } from '@angular/core';
import { config } from "../../../env/config.prod";
import { DecimalPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CartResponse } from '../../core/interfaces/Product/Response/cartResponse';
import { ProductDto } from '../../core/interfaces/Product/productDto';
import { PurchaseDetailDto } from '../../core/interfaces/Product/UserInteract/purchaseDetailDto';

@Injectable({
  providedIn: 'root'
})
export class CartsService {
  private apiUrl = `${config.apiURL}carts/`

  constructor(
    private http: HttpClient
  ) { }

  getCartCount(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}`)
  }

  getMyCart(): Observable<CartResponse> {
    return this.http.get<CartResponse>(`${this.apiUrl}myCart`);
  }

  AddProductToCart(cartItem: PurchaseDetailDto): Observable<CartResponse> {
    return this.http.put<CartResponse>(`${this.apiUrl}addProductToCart`, cartItem);
  }

  UpdateQuantity(quantity: number, detailId: string, optionId: string){
    return this.http.get(`${this.apiUrl}detail/${detailId}/option/${optionId}/adjust/${quantity}`);
  }

  RemoveItem(detailId: string, optionId: string) {
    return this.http.delete(`${this.apiUrl}detail/${detailId}/option/${optionId}/remove`);
  }

  ClearCart() {
    return this.http.delete(`${this.apiUrl}clear`);
  }
}