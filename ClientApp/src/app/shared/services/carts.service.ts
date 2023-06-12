import { Injectable } from '@angular/core';
import { config } from "../../env/config.prod";
import { DecimalPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CartResponse } from '../../interfaces/Product/Response/cartResponse';

@Injectable({
  providedIn: 'root'
})
export class CartsService {
  private apiUrl = `${config.apiURL}carts/`

  constructor(
    private pipe: DecimalPipe,
    private http: HttpClient
  ) { }

  getMyCart(): Observable<CartResponse[]> {
    return this.http.get<CartResponse[]>(`${this.apiUrl}myCart`);
  }
}
