import { Component, OnInit, Input } from '@angular/core';

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
  @Input() value: string;
  @Input() inputFocus: boolean;
  @Input() ariaRequired: boolean;

  constructor() { }

  ngOnInit(): void {
  }

  processChangeEvent = () => {

  }

}
