import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.styl']
})
export class TextInputComponent implements OnInit {

  @Input() placeholder: string;
  @Input() label: string;
  @Input() iconClass: string;
  @Input() type: string;
  @Input() descriptionAriaLabel: string;
  @Input() subText: string;
  @Input() maxLength: number;
  @Input() textOptional: string;
  @Input() inputFocus: boolean;
  @Input() ariaRequired: boolean;
  @Input() inputModel: string;
  @Output() inputModelChange = new EventEmitter<string>();
  public isPassword: boolean;

  constructor() { }

  ngOnInit(): void {
    this.isPassword = this.type === 'password' ? true : false;
  }

  controlsShowPassword(): void {
    if (this.type === 'password') {
      this.type = 'text';
    } else {
      this.type = 'password';
    }
  }


}
