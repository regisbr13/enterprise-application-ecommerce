import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.styl']
})
export class TextInputComponent implements OnInit {

  @Input() placeholder: string;
  @Input() text: string;
  @Input() iconClass: string;
  @Input() type: string;

  constructor() { }

  ngOnInit(): void {
  }

}
