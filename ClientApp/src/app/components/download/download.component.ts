import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FilesService } from '../../shared/services/files.service';

@Component({
  selector: 'app-download',
  templateUrl: './download.component.html',
  styleUrls: ['./download.component.scss']
})
export class DownloadComponent implements OnInit {
  @Input() fileUrl!: string;
  message!: string;
  progress!: number;

  constructor(private filesService: FilesService) { }

  download = () => {
    this.filesService.getPhoto(this.fileUrl).subscribe((response: any) => {
      if (response.type === HttpEventType.UploadProgress)
        this.progress = Math.round((100 * response.loaded) / response.total);
      else if (response.type === HttpEventType.Response) {
        this.message = 'Download success.';
        this.downloadFile(response);
      }
    });
  }

  private downloadFile = (data: HttpResponse<Blob>) => {
    if (data.body) {
      const downloadedFile = new Blob([data.body], { type: data.body.type });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = this.fileUrl;
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);
    } else {
      console.error('Response body is null');
    }
  }

  ngOnInit(): void { }
}
