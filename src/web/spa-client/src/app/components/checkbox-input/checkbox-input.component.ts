import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox-input.component.html',
  styleUrls: ['./checkbox-input.component.styl']
})
export class CheckboxComponent implements OnInit {
  @Input() label: string;

  constructor() { }

  ngOnInit(): void {
  }

}
