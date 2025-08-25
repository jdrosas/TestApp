import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { GifData } from '../models/gif.model';
import { DefaultResponse } from '../../../core/models/default-response.model';


@Injectable({
  providedIn: 'root'
})
export class GifService {
  private apiURL = `${environment.API_URL}Gif?query=`

  constructor(private http: HttpClient) { }

  getGifAsync(query: string) {
    return this.http.get<DefaultResponse<GifData[]>>(`${this.apiURL}${query}`)
  }
}
