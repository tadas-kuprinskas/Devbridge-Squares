import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Point } from 'src/app/models/Point';
import { PointServiceService } from 'src/app/services/point-service.service';

@Component({
  selector: 'app-point-item',
  templateUrl: './point-item.component.html',
  styleUrls: ['./point-item.component.css']
})
export class PointItemComponent implements OnInit {
  @Input() point: Point;
  @Output() deletePoint: EventEmitter<Point> = new EventEmitter();

  constructor(private pointService:PointServiceService) { }

  ngOnInit(): void {
  }

  onDelete(point) {
    this.deletePoint.emit(point);
  }

}
