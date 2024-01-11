import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {WishListResponse} from "@core/interfaces/Product/UserInteract/Response/wishListResponse";


@Injectable({
  providedIn: 'root'
})
export class WisheslistService {
  private apiUrl = `${config.apiURL}wishList/`

  constructor(
    private http: HttpClient
  ) {
  }

  getWishList(): Observable<WishListResponse> {
    return this.http.get<WishListResponse>(`${this.apiUrl}`);
  }

  addToWishList(optionId: string) {
    return this.http.get(`${this.apiUrl}add/${optionId}`);
  }

  RemoveItem(wishListId: string, optionId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}${wishListId}/option/${optionId}`);
  }

  DeleteAllProductsFromWishList(): Observable<any> {
    return this.http.delete(`${this.apiUrl}/deleteAll`);
  }
}
