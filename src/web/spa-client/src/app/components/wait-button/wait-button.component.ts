import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'wait-button',
  templateUrl: './wait-button.component.html',
  styleUrls: ['./wait-button.component.styl']
})
export class WaitButtonComponent implements OnInit {

  constructor() { }
  @Input() text: string;
  @Input() iconClass: string;
  @Input() type: string;
  @Input() descriptionAriaLabel: string;
  @Input() classes: string;
  @Input() disabled: boolean;
  @Output() onClick = new EventEmitter<any>();
  isWaiting = false;

  ngOnInit(): void {
  }

  async doAction(event) {

    if (this.isWaiting)
      return;

    const result = Promise.resolve(this.onClick.emit(event));
    this.isWaiting = true;
    await result;
    this.isWaiting = false;
  }
}
