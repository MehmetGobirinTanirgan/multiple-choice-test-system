import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AdminInfoModel } from 'src/models/AdminInfoModel';
import { AdminLoginModel } from 'src/models/AdminLoginModel';
import { tap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AdminService {
  constructor(private httpClient: HttpClient) {}

  adminData: AdminInfoModel | undefined;
  jwtHelperService: JwtHelperService = new JwtHelperService();

  login(adminLoginModel: AdminLoginModel) {
    return this.httpClient
      .post<AdminInfoModel>('Admin/Login', adminLoginModel)
      .pipe(
        tap((res) => {
          this.saveAdminData(res);
        })
      );
  }

  saveAdminData(adminData: AdminInfoModel) {
    localStorage.setItem('admin', JSON.stringify(adminData));
  }

  getToken(): string | undefined {
    const admin: AdminInfoModel = JSON.parse(localStorage.getItem('admin')!);

    if (admin != undefined && admin != null) {
      return admin.token;
    }
    return undefined;
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    if (token !== null) {
      return !this.jwtHelperService.isTokenExpired(token);
    }
    return false;
  }

  logout(): void {
    localStorage.removeItem('admin');
  }
}
