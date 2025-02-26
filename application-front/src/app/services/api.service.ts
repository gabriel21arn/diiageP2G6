import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'https://localhost:7186/api';
  private apiKey = 'MaCleSecrete';

  constructor(private http: HttpClient) {}

  getData<T>(endpoint: string): Observable<T> {
    const headers = new HttpHeaders({
      'x-api-key': this.apiKey
    });

    return this.http.get<T>(`${this.apiUrl}/${endpoint}`, { headers });
  }

  createUser(userData: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'x-api-key': this.apiKey
    });

    return this.http.post<any>(`${this.apiUrl}/users`, userData, { headers });
  }
}
