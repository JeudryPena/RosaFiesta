import { Component, Input, OnInit } from '@angular/core';
import { NgxFileDropEntry } from 'ngx-file-drop';

@Component({
  selector: 'app-upload-images',
  templateUrl: './upload-images.component.html',
  styleUrls: ['./upload-images.component.scss']
})
export class UploadImagesComponent implements OnInit {
  @Input() pictures: any[] = [];
  @Input() public uploadFiles: File[] = [];
  @Input() public multiple: boolean = false;
  @Input() public read: boolean = false;

  constructor(

  ) {

  }

  ngOnInit(): void {
    for (const f of this.uploadFiles) {
      this.preview(f);
    }
  }

  preview(f: File) {
    console.log(f);
    const reader = new FileReader();
    reader.readAsDataURL(f);
    reader.onload = () => {
      this.pictures.push(reader.result);
    };
  }

  removePicture(index: number) {
    this.pictures.splice(index, 1);
    this.uploadFiles.splice(index, 1);
  }

  public dropped(files: NgxFileDropEntry[]) {
    for (const droppedFile of files) {
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {
          this.uploadFiles.push(file);
          this.preview(file);
        });
      }
    }
  }
}
