import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = `${config.apiURL}carts/`

  constructor() {
  }
}
