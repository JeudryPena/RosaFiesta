import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { config } from '../../env/config.dev';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private apiUrl = `${config.apiURL}users/`

  constructor(
    private http: HttpClient
  ) { }

  UserName(userId: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}${userId}/user-name`);
  }
}
