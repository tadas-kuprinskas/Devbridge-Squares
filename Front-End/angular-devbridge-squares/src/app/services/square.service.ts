import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Square } from '../models/Square';

@Injectable({
  providedIn: 'root'
})
export class SquareService {

  squaresUrl:string = 'https://localhost:44370/square';

  constructor(private http: HttpClient) { }

  getSquares():Observable<Square[]> {
    return this.http.get<Square[]>(`${this.squaresUrl}`);
  }
}
