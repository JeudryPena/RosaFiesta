import {Component} from '@angular/core';
import * as pdfMake from "pdfmake/build/pdfmake";
import * as pdfFonts from 'pdfmake/build/vfs_fonts';

(<any>pdfMake).vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-pdf',
  templateUrl: './pdf.component.html',
  styleUrl: './pdf.component.sass'
})
export class PdfComponent {

  createPdf() {
    const pdfDefinition: any = {
      content: [
        {
          text: 'hola mundo'
        }
      ]
    };

    const pdf = pdfMake.createPdf(pdfDefinition);
    pdf.open();
  }

}
