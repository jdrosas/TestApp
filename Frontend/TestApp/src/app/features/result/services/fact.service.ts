import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { FactData } from '../models/fact.model';
import { DefaultResponse } from '../../../core/models/default-response.model';

@Injectable({
  providedIn: 'root'
})
export class FactService {
  private apiURL = `${environment.API_URL}Fact`

  constructor(private http: HttpClient) { }

  getFactAsync() {
    return this.http.get<DefaultResponse<FactData>>(this.apiURL);
  }

}
