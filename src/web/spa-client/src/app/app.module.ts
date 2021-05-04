import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { WaitButtonComponent } from './components/wait-button/wait-button.component';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CheckboxComponent } from './components/checkbox-input/checkbox-input.component';
import { AccessBarComponent } from './components/access-bar/access-bar.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    WaitButtonComponent,
    TextInputComponent,
    CheckboxComponent,
    AccessBarComponent,
    NavBarComponent,
    HomeComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
