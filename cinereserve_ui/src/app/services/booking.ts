import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class Booking {
  api = 'https://localhost:7168/api';

  constructor(private http: HttpClient) {}

  book(data: any) {
    return this.http.post(`${this.api}/book`, data);
  }
}