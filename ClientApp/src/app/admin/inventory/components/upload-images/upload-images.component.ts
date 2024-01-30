import {Component, Input, OnInit} from '@angular/core';
import {NgxFileDropEntry} from 'ngx-file-drop';

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
  @Input() imageFirst!: number | null;

  constructor() {

  }

  async ngOnInit(): Promise<void> {
    for (const f of this.uploadFiles) {
      await this.preview(f);
    }
  }

  makeDefault(index: number) {
    this.imageFirst = index;
  }

  async preview(f: File) {
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
          if (this.uploadFiles.length == 0)
            this.imageFirst = 0;
          this.uploadFiles.push(file);
          this.preview(file);
        });
      }
    }
  }
}
