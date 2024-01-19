import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {AddressResponse} from "@core/interfaces/Security/Response/addressResponse";
import {AddressPreviewResponse} from "@core/interfaces/Security/Response/addressPreviewResponse";
import {AddressDto} from "@core/interfaces/Security/addressDto";

@Injectable({
  providedIn: 'root'
})
export class AddressesService {

  private apiUrl = `${config.apiURL}address/`

  constructor(
    private readonly http: HttpClient
  ) {
  }

  retrieveAll(): Observable<AddressPreviewResponse[]> {
    return this.http.get<AddressPreviewResponse[]>(`${this.apiUrl}myAddresses`);
  }

  retrieveById(id: string): Observable<AddressResponse> {
    return this.http.get<AddressResponse>(`${this.apiUrl}${id}`);
  }

  persist(address: AddressDto) {
    return this.http.post(`${this.apiUrl}`, address);
  }

  update(address: AddressDto, id: string) {
    return this.http.put(`${this.apiUrl}${id}`, address);
  }

  delete(id: string) {
    return this.http.delete(`${this.apiUrl}${id}`);
  }
}
