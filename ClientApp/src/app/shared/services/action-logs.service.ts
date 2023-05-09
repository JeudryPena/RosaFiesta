import { Injectable } from '@angular/core';
import { config } from '../../env/config.prod';
import { HttpClient } from '@angular/common/http';
import {
  CancellationToken,
  CancellationTokenSource,
} from 

@Injectable({
  providedIn: 'root'
})
export class ActionLogsService {
  constructor() {
    const apiURL = config.apiURL;
  }

  public getActionLogs() {

  }


}
