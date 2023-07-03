import { Component } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { ModalProductComponent } from '../modal-product/modal-product.component';
import { NgxFileDropEntry } from 'ngx-file-drop';


@Component({
  selector: 'app-coupens',
  templateUrl: './coupens.component.html',
  styleUrls: ['./coupens.component.css']
})

export class CoupensComponent {
  public dropped(files: NgxFileDropEntry[]) {
    for (const droppedFile of files) {

      // Es un archivo
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {

          const reader = new FileReader();
          reader.readAsDataURL(file);
          reader.onload = () => {
            
          };
          
        });
      }
    }
  }
}
