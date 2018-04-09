import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-show-single',
  templateUrl: './show-single.component.html',
  styleUrls: ['./show-single.component.css']
})
export class ShowSingleComponent implements OnInit {

  @Input() public showIndex: number;
  @Input() public show: FormGroup;

  @Output() public removeShowClicked: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  static createShow() {
    return new FormGroup(
      {
        date: new FormControl([]),
        venue: new FormControl([]),
        city: new FormControl([]),
        country: new FormControl([])
      });
  }

  ngOnInit() {
  }

}
