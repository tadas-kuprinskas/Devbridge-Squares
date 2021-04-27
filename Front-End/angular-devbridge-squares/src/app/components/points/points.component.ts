import { Component, OnInit } from '@angular/core';
import { Point } from 'src/app/models/Point';
import { PointServiceService } from 'src/app/services/point-service.service';

@Component({
  selector: 'app-points',
  templateUrl: './points.component.html',
  styleUrls: ['./points.component.css']
})
export class PointsComponent implements OnInit {
  points:Point[];
  constructor(private pointService:PointServiceService) { }

  ngOnInit(): void {
    this.pointService.getPoints().subscribe(points => {
      this.points = points;
    })
  }

  addPoint(point:Point) {
    this.pointService.addPoint(point).subscribe(point => {
      if(point !== null) {
        this.points.push(point)
      } else {
        alert("There is already such point added.")
      }
    })
  }

  deletePoint(point:Point) {
    // remove from ui
    this.points = this.points.filter(p => p.id !== point.id);
    // remove from db
    this.pointService.deletePoint(point).subscribe();
  }

  clearPoints() {
    // remove from ui
    this.points = [];
    // remove from db
    this.pointService.clearPoints().subscribe();
  }

}
