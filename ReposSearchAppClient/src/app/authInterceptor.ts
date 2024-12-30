import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpInterceptor } from '@angular/common/http';
import { AuthService } from './services/auth.service';  // Your AuthService

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    //An interception that insert to every reuest the JWT
    const token = this.authService.getToken();  // Retrieve token from localStorage or service
    if (token) {
      const cloned = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
      return next.handle(cloned);
    }
    return next.handle(req);
  }
}
