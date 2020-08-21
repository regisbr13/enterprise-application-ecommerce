import { Component, OnInit, Input } from '@angular/core';

@Component({
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
  @Input() click: () => void | Promise<any>;
  @Input() class: string;
  isWaiting = false;

  ngOnInit(): void {
  }

  async doAction() {
    if (this.isWaiting)
      return;
    const result = Promise.resolve(this.click());
    this.isWaiting = true;
    await result;
    this.isWaiting = false;
  };

}
