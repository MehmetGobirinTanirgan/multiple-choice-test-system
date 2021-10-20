import { Injectable } from '@angular/core';
import { UserDataModel } from 'src/models/UserDataModel';

@Injectable()
export class UserService {
  constructor() {}

  saveUserData(userData: UserDataModel): void {
    localStorage.setItem('user', JSON.stringify(userData));
  }

  getUserData(): UserDataModel {
    return JSON.parse(localStorage.getItem('user')!);
  }

  removeUserData(): void {
    localStorage.removeItem('user');
  }
}
