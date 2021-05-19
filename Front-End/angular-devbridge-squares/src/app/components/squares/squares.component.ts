import { Component, OnInit } from '@angular/core';
import { Square } from 'src/app/models/Square';
import { SquareService } from 'src/app/services/square.service';

@Component({
  selector: 'app-squares',
  templateUrl: './squares.component.html',
  styleUrls: ['./squares.component.css']
})
export class SquaresComponent implements OnInit {

  numberOfSquares:number;
  squares:Square[];
  
  constructor(private squareService: SquareService) { }

  ngOnInit(): void {
    this.squareService.getSquares().subscribe(squares => {
      this.squares = squares;
      this.numberOfSquares = squares.length;
  });
}

}
