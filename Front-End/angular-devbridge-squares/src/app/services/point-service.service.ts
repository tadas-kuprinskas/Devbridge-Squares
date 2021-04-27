import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Point } from '../models/Point';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PointServiceService {
  pointsUrl:string = 'https://localhost:44370/point';

  constructor(private http:HttpClient) { }

  getPoints():Observable<Point[]> {
    return this.http.get<Point[]>(`${this.pointsUrl}`);
  }

  deletePoint(point:Point):Observable<Point>{
    const url = `${this.pointsUrl}/${point.id}`;
    return this.http.delete<Point>(url, httpOptions);
  }

  addPoint(point:Point):Observable<Point>{
    return this.http.post<Point>(this.pointsUrl, point, httpOptions);
  }

}
