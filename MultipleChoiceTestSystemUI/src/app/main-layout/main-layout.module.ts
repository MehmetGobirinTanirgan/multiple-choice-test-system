import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayoutComponent } from './main-layout.component';
import { TestPageComponent } from './test-page/test-page.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ResultPageComponent } from './result-page/result-page.component';



@NgModule({
  declarations: [MainLayoutComponent,TestPageComponent,ResultPageComponent],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    NgbModule
  ]
})
export class MainLayoutModule { }
