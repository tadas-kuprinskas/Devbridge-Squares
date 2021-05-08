import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-clear-points',
  templateUrl: './clear-points.component.html',
  styleUrls: ['./clear-points.component.css']
})
export class ClearPointsComponent implements OnInit {
  @Output() clearPoints:EventEmitter<any> = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

  onClick() {
    this.clearPoints.emit();
  }

}
