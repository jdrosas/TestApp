import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.prod';
import { HistoryCreateData, HistoryData } from '../models/history.model';
import { DefaultResponse } from '../../../core/models/default-response.model';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  private apiURL = `${environment.API_URL}History`

  constructor(private http: HttpClient) { }

  getHistoryAsync() {
    return this.http.get<DefaultResponse<HistoryData[]>>(this.apiURL);
  }

  createHistoryAsync(historyData: HistoryCreateData) {
    return this.http.post<DefaultResponse<HistoryCreateData>>(`${this.apiURL}/CreateHistory`, historyData);
  }

}
