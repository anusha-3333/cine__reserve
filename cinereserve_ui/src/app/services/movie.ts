import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class Movie {
  api = 'https://localhost:7168/api';

  constructor(private http: HttpClient) {}

  getMovies() {
    return this.http.get(this.api);
  }
}