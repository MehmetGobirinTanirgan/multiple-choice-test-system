import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/services/admin.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css'],
})
export class AdminLayoutComponent implements OnInit {
  constructor(private adminService: AdminService, private router:Router) {}
  ngOnInit(): void {}

  logout(): void {
    this.adminService.logout();
    this.router.navigate([""]);
  }
}
