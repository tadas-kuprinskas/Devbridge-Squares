import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-point',
  templateUrl: './add-point.component.html',
  styleUrls: ['./add-point.component.css']
})
export class AddPointComponent implements OnInit {

  @Output() addPoint:EventEmitter<any> = new EventEmitter();
  xCoordinate: number;
  yCoordinate: number;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    const point = {
      xCoordinate: this.xCoordinate,
      yCoordinate: this.yCoordinate
    }
    this.addPoint.emit(point);
  }

}
