import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { config } from '../../env/config.dev';
import { MultipleImageDto } from '../../interfaces/Product/UserInteract/multipleImageDto';

@Injectable({
  providedIn: 'root'
})
export class FilesService {
  private apiUrl = `${config.apiURL}files/`

  constructor(
    private http: HttpClient
  ) { }

  public getPhoto(fileUrl: string) {
    return this.http.get(`${this.apiUrl}getPhoto?fileUrl=${fileUrl}`, {
      reportProgress: true,
      observe: 'events',
      responseType: 'blob'
    });
  }

  GetPhotos() {
    this.http.get('/api/getPhotos').subscribe((data: any) => {
      data.forEach((fileData: any) => {
        let blob = new Blob([fileData], { type: 'application/octet-stream' });
        console.log(blob);
      })
    })
  }

  public getAllPhotos() {
    return this.http.get(`${this.apiUrl}getAllPhotos`);
  }

  UploadFile(file: any): string {
    if (file.length === 0)
      throw new Error('You must select an image');
    let fileToUpload = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    let filesToUpload: string = '';
    this.http.post(`${this.apiUrl}image`, formData).subscribe({
      next: (event: any) => {
        filesToUpload = event;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        throw new Error('Something went wrong');
      }
    });
    return filesToUpload;
  }

  UpdateFiles(files: any, optionId: number): Observable<MultipleImageDto[]> {
    if (files.length > 5)
      throw new Error('You cant upload more than 5 images');
    let filesToUpload: File[] = files; 
    const formData = new FormData();
    console.log(filesToUpload)
    console.log(files)
    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });
    return this.http.put<MultipleImageDto[]>(`${this.apiUrl}updateFiles/options/${optionId}`, formData);
  }

  UploadFiles(files: any): Observable<MultipleImageDto[]> {
    if (files.length > 5)
      throw new Error('You cant upload more than 5 images');

    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });
    return this.http.post<MultipleImageDto[]>(`${this.apiUrl}multiImages`, formData);
  }
}
