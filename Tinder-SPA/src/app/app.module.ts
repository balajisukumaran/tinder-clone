import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent
   ],
  imports: [
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ ErrorInterceptorProvider, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
