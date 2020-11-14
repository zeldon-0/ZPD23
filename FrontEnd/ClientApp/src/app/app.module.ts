import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PasswordLoginComponent } from './components/password-login/password-login.component';
import { QuestionLoginComponent } from './components/question-login/question-login.component';
import { AuthGuard } from './guards/auth.guard';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PasswordLoginComponent,
    QuestionLoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full',  canActivate: [AuthGuard]},
      { path: 'passwordLogin', component: PasswordLoginComponent  },
      { path: 'questionLogin', component: QuestionLoginComponent  },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
