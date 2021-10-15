import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDataModel } from 'src/models/UserDataModel';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css'],
})
export class MainLayoutComponent implements OnInit {
  constructor(private userService: UserService, private router: Router) {}

  userData: UserDataModel | undefined;
  pageHeader:string = "Exam";
  ngOnInit(): void {
    this.userData = this.userService.getUserData();
  }

  goBack() {
    this.userService.removeUserData();
    this.router.navigate(['']);
  }
}
