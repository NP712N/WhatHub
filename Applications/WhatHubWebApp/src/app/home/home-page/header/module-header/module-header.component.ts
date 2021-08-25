import { coerceBooleanProperty } from '@angular/cdk/coercion';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'what-hub-module-header',
  templateUrl: './module-header.component.html',
  styleUrls: ['./module-header.component.scss']
})
export class ModuleHeaderComponent implements OnInit {

  private _isActive: boolean;
  @Input()
  get isActive() { return this._isActive; }
  set isActive(value: any) { this._isActive = coerceBooleanProperty(value); }

  constructor() {

  }

  ngOnInit(): void {
    console.log(this.isActive);
  }

}
