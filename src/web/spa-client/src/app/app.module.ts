import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { WaitButtonComponent } from './components/wait-button/wait-button.component';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CheckboxComponent } from './components/checkbox-input/checkbox-input.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    WaitButtonComponent,
    TextInputComponent,
    CheckboxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
