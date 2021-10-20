import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AdminLoginModel } from 'src/models/AdminLoginModel';
import { UserDataModel } from 'src/models/UserDataModel';
import { AdminService } from 'src/services/admin.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-front-page',
  templateUrl: './front-page.component.html',
  styleUrls: ['./front-page.component.css'],
})
export class FrontPageComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private ngbModal: NgbModal,
    private adminService: AdminService,
    private userService: UserService
  ) {}
  @ViewChild('adminLoginModal') adminLoginModal: any;
  userInfoForm: FormGroup | undefined;
  adminLoginForm: FormGroup | undefined;
  ngOnInit(): void {
    this.createUserInfoForm();
    this.createAdminLoginForm();
  }

  createUserInfoForm(): void {
    this.userInfoForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      surname: ['', [Validators.required, Validators.maxLength(50)]],
      emailAddress: [
        '',
        [Validators.required, Validators.email, Validators.maxLength(50)],
      ],
      phoneNumber: ['', Validators.maxLength(50)],
    });
  }

  takeExam(): void {
    if (this.userInfoForm?.valid) {
      this.userService.saveUserData(new UserDataModel(this.userInfoForm.value));
      this.router.navigate(['test']);
    }
  }

  createAdminLoginForm(): void {
    this.adminLoginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.maxLength(50)]],
      password: [
        '',
        [
          Validators.required,
          Validators.maxLength(50),
          Validators.minLength(8),
        ],
      ],
    });
  }

  adminLogin(): void {
    if (this.adminLoginForm?.valid) {
      const adminLoginData = new AdminLoginModel(this.adminLoginForm.value);
      this.adminService.login(adminLoginData).subscribe(
        (success) => {
          this.router.navigate(['admin/questions']);
        },
        (error) => {
          alert('Login failed');
        }
      );
    }
  }

  openAdminModal() {
    this.ngbModal.open(this.adminLoginModal, { centered: true });
  }
}
