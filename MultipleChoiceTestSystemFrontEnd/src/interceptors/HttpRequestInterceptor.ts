import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AdminService } from 'src/services/admin.service';

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
  constructor(private adminService:AdminService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.adminService.getToken();
    if(token != null){
      request = request.clone({
        setHeaders: {
          'Authorization': `Bearer ${token}`,
        },
      });
    }
    request = request.clone({
      url: `https://localhost:44319/api/${request.url}`
    })
    return next.handle(request);
  }
}
