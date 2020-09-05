import { FormGroup } from '@angular/forms';
import { UserViewModel } from './../../models/user-view-model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.styl']
})
export class RegisterComponent implements OnInit {

  private newUser: UserViewModel;
  private registerForm: FormGroup;
  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    console.log("teste");
  }
}
