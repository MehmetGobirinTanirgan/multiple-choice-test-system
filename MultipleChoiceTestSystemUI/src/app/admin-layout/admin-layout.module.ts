import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutComponent } from './admin-layout.component';
import { RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { QuestionService } from 'src/services/question.service';
import { ReactiveFormsModule } from '@angular/forms';
import { AddNewQuestionComponent } from './add-new-question/add-new-question.component';



@NgModule({
  declarations: [
    AdminLayoutComponent,
    AdminHomeComponent,
    AddNewQuestionComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    NgbModule
  ]
})
export class AdminLayoutModule { }
