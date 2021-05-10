import { HttpClient, HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { PointServiceService } from 'src/app/services/point-service.service';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent {

  constructor(private pointService:PointServiceService) { }


  chosenFiles: FileList;
  existingFile: File;
  progress = 0;
  msg = '';

  FileDetail: Observable<any>;


  ngOnInit(): void {
  }

  chooseFile(event): void {
    this.chosenFiles = event.target.files;
  }

  upload(): void {
    this.progress = 0;
  
    this.existingFile = this.chosenFiles.item(0);

    this.pointService.uploadFile(this.existingFile).subscribe( (event) => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event instanceof HttpResponse) {
          this.msg = event.body.message;     
        }
      }, (error) => {
        this.progress = 0;
        this.msg = 'Error occured while uploading file';
        this.existingFile = undefined;
      });

    this.chosenFiles = undefined;
    this.pointService.getPoints();
  }  

}


