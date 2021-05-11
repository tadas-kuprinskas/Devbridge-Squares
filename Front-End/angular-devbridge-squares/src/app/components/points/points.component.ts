import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Point } from 'src/app/models/Point';
import { PointServiceService } from 'src/app/services/point-service.service';

@Component({
  selector: 'app-points',
  templateUrl: './points.component.html',
  styleUrls: ['./points.component.css']
})
export class PointsComponent implements OnInit {
  points:Point[];
  fileList: FileList;
  fileContent: string;
  
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
        alert("Dublicate point")
      }
    },
    (err) => {alert("Range should be between -5000 and 5000")}
    );
    
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
