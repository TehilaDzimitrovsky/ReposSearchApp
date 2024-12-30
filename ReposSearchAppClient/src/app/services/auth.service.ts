import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private tokenKey = 'auth_token';
  serviceBase: string = "https://localhost:7269/Auth/";

  constructor(private http: HttpClient) {}

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);  // Get the JWT token from localStorage
  }

  setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);  // Store the JWT token in localStorage
  }

  getTokenFromServer() {
    return this.http.get<{ token: string }>(`${this.serviceBase}GetSecretKey`).pipe(
      tap(response => {
        this.setToken(response.token);  // Store token after receiving
      })
    );
  }
}
