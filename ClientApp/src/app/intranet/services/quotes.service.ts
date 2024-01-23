import {Injectable} from '@angular/core';
import {config} from "@env/config.prod";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {QuoteDto} from "@core/interfaces/Enterprise/quoteDto";
import {OficializeDto} from "@core/interfaces/Product/UserInteract/OficializeDto";

@Injectable({
  providedIn: 'root'
})
export class QuotesService {

  private apiUrl = `${config.apiURL}quotes/`

  constructor(
    private readonly http: HttpClient
  ) {
  }

  makeQuote(quote: QuoteDto): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, quote);
  }

  getQuotesCount(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}count`);
  }

  oficializeQuote(oficializeDto: OficializeDto) {
    return this.http.put<any>(`${this.apiUrl}oficialize`, oficializeDto);
  }
}
