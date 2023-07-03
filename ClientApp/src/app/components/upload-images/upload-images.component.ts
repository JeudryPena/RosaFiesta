import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { config } from '../../env/config.dev';
import { FilesService } from '../../shared/services/files.service';
import { NgxFileDropEntry } from 'ngx-file-drop';

@Component({
  selector: 'app-upload-images',
  templateUrl: './upload-images.component.html',
  styleUrls: ['./upload-images.component.scss']
})
export class UploadImagesComponent implements OnInit {
  errorMessage: any;
  showError = false;
  progress!: number;
  message!: string;

  pictures: any[] = [];
  @Input() public uploadFiles: any[] = [];
  @Input() public multiple: boolean = false;

  @Output() public onImagesUploadFinished = new EventEmitter();
  @Output() public onImagesUpload = new EventEmitter();
  @Output() public onImagesRemove = new EventEmitter();

  constructor(
    private service: FilesService
  ) {

  }

  ngOnInit(): void {
    this.preview(this.uploadFiles);
  }

  preview(file: File[]) {
    for (const f of file) {
      const reader = new FileReader();
      reader.readAsDataURL(f);
      reader.onload = () => {
        this.pictures.push(reader.result);
      };
    }
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
        });
      }
    }
    this.preview(this.uploadFiles);
  }
}
