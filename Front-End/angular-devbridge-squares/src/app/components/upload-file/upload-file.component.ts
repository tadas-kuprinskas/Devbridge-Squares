import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent {

   //fileContent: string = '';

  // public onChange(fileList: FileList): void {
  //   let file = fileList[0];
  //   let fileReader: FileReader = new FileReader();
  //   let self = this;
  //   fileReader.onloadend = function(x) {
  //     self.fileContent = <string>fileReader.result;
  //   }
  //   fileReader.readAsText(file);
  // }

  @Input() fileList: FileList;
  @Input() fileContent: string;
  @Output() addFromFile: EventEmitter<FileList> = new EventEmitter();

  public onChange(fileList){
    this.addFromFile.emit(fileList);
  }

}
