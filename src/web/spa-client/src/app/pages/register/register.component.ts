import { FormGroup } from '@angular/forms';
import { UserViewModel } from './../../models/user-view-model';
import { Component, OnInit, Injectable } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.styl']
})

@Injectable()
export class RegisterComponent implements OnInit {

  private registerForm: FormGroup;
  public newUser: UserViewModel;
  public password: string;
  public checkPassword: string;

  constructor() {
  }

  ngOnInit(): void {
    this.newUser = new UserViewModel();
  }

  onSubmit(): void {
    console.log(this.newUser);
  }
}
