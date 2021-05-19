import { Component, Input, OnInit } from '@angular/core';
import { Square } from 'src/app/models/Square';

@Component({
  selector: 'app-square-item',
  templateUrl: './square-item.component.html',
  styleUrls: ['./square-item.component.css']
})
export class SquareItemComponent implements OnInit {

  @Input() square: Square;
  
  constructor() { }

  ngOnInit(): void {
  }

}
