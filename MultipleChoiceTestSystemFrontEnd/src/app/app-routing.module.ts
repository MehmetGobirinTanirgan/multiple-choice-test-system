import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRouteGuardService } from 'src/services/admin-route-guard.service';
import { AddNewQuestionComponent } from './admin-layout/add-new-question/add-new-question.component';
import { AdminHomeComponent } from './admin-layout/admin-home/admin-home.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { FrontPageComponent } from './front-page/front-page.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { ResultPageComponent } from './main-layout/result-page/result-page.component';
import { TestPageComponent } from './main-layout/test-page/test-page.component';

const routes: Routes = [
  { path: '', component: FrontPageComponent },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'test',
        component: TestPageComponent,
      },
      {
        path: 'result',
        component: ResultPageComponent,
      },
    ],
  },
  {
    path: '',
    component: AdminLayoutComponent,
    canActivate: [AdminRouteGuardService],
    children: [
      {
        path: 'admin/questions',
        component: AdminHomeComponent,
      },
      {
        path: 'admin/new-question',
        component: AddNewQuestionComponent,
      },
      {
        path: 'admin/question-management',
        component: AdminHomeComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
