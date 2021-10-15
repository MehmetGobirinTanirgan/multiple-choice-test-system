import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpRequestInterceptor } from 'src/interceptors/HttpRequestInterceptor';
import { AdminRouteGuardService } from 'src/services/admin-route-guard.service';
import { AdminService } from 'src/services/admin.service';
import { DataService } from 'src/services/data.service';
import { QuestionService } from 'src/services/question.service';
import { ResultService } from 'src/services/result.service';
import { UserService } from 'src/services/user.service';
import { AdminLayoutModule } from './admin-layout/admin-layout.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FrontPageComponent } from './front-page/front-page.component';
import { MainLayoutModule } from './main-layout/main-layout.module';

@NgModule({
  declarations: [AppComponent, FrontPageComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
    MainLayoutModule,
    AdminLayoutModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpRequestInterceptor,
      multi: true,
    },
    AdminService,
    AdminRouteGuardService,
    QuestionService,
    UserService,
    DataService,
    ResultService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
