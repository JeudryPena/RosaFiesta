import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { config } from '../../env/config.dev';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilesService {
  private apiUrl = `${config.apiURL}files/`

  constructor(
    private http: HttpClient
  ) { }

  UploadFile(file: any): string {
    if (file.length === 0) 
      throw new Error('You must select an image');
    let fileToUpload = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    let filesToUpload: string = '';
    this.http.post(`${this.apiUrl}image`, file).subscribe({
      next: (event:any) => {
        filesToUpload = event;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        throw new Error('Something went wrong');
      }
    });
    return filesToUpload;
  }

  UploadFiles(files: any): string[] {
    if (files.length > 5) 
      throw new Error('You cant upload more than 5 images');
    
    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });
    let uploadFiles: string[] = [];
    this.onUploadFiles(formData).subscribe({
      next: (event: any) => {
        console.log
        uploadFiles = event;
      }, error: (err: HttpErrorResponse) => {
        console.log(err);
        throw new Error('Something went wrong');
      }
    });
    return uploadFiles;
  }

  onUploadFile(files: any) {
    return ;
  }

  onUploadFiles(files: any) {
    return this.http.post(`${this.apiUrl}multiImages`, files);
  }
}
