import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class TokenService {

  key = 'token';

  setToken(token: string) {
    localStorage.setItem(this.key, token);
  }

  getToken() {
    return localStorage.getItem(this.key);
  }

  clear() {
    localStorage.removeItem(this.key);
  }
}