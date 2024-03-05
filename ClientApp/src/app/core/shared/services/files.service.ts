import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {lastValueFrom} from 'rxjs';
import {config} from '@env/config.dev';
import {MultipleImageDto} from '../../interfaces/Product/UserInteract/multipleImageDto';
import {InvoiceAction} from "@core/interfaces/invoice";

import * as pdfMake from "pdfmake/build/pdfmake";
import * as pdfFonts from 'pdfmake/build/vfs_fonts';
import {OrderResponse} from "@core/interfaces/Product/UserInteract/Response/orderResponse";
import {PurchaseOrderOptionResponse} from "@core/interfaces/Product/UserInteract/Response/PurchaseOrderOptionResponse";
import {
  AnalyticDataResponse,
  MostPurchasedProductsWithDateResponse
} from "@core/interfaces/Product/Response/MostPurchasedProductsResponse";

(<any>pdfMake).vfs = pdfFonts.pdfMake.vfs;

@Injectable({
  providedIn: 'root'
})
export class FilesService {
  private apiUrl = `${config.apiURL}files/`


  constructor(
    private http: HttpClient
  ) {
  }

  generateReport(start: Date, end: Date, analyticData: AnalyticDataResponse, orderComparative: any[], multi: MostPurchasedProductsWithDateResponse[], userName: string) {
    const products: any[] = multi.map(x => {
      const options = x.series.map(y => {
        return {
          product: x.name,
          quantity: y.value,
          date: y.name
        }
      });
      return options;
    }).flat();
    let docDefinition = {
      content: [
        {
          text: 'RosaFiesta',
          fontSize: 16,
          alignment: 'center',
          color: '#1980e5'
        },
        {
          text: 'Reporte',
          fontSize: 20,
          bold: true,
          alignment: 'center',
          decoration: 'underline',
          color: 'skyblue'
        },
        {
          text: 'Detalles del Reporte',
          style: 'sectionHeader'
        },
        {
          columns: [
            [
              {text: `Desde la Fecha: ${start.toLocaleDateString()}`,},
              {text: `Hasta la Fecha: ${end.toLocaleDateString()}`}
            ],
            [
              {
                text: `Generado por: ${userName}`,
                alignment: 'right'
              }
            ]
          ]
        },
        {
          text: 'Los 5 Productos mas comprados en la fecha designada',
          style: 'sectionHeader'
        },
        {
          table: {
            headerRows: 1,
            widths: ['*', 'auto', 'auto'],
            body: [
              ['Product', 'Cantidad', 'Fecha'],
              ...products.map(p => ([p.product, p.quantity, p.date]))
            ]
          }
        },
        {
          text: 'Comparación de Ordenes, Cotizaciones, Devoluciones y Productos no comprados durante el periodo',
          style: 'sectionHeader'
        },
        {
          table: {
            headerRows: 1,
            widths: ['*', 'auto'],
            body: [
              ['Producto', 'Cantidad Comprada'],
              ...orderComparative.map(p => ([p.name, p.value]))
            ]
          }
        },
        {
          text: 'Exito del Negocio',
          style: 'sectionHeader'
        },
        {
          text: `Total de Clientes: ${analyticData.totalClients}`,
          margin: [0, 0, 0, 15]
        },
        {
          text: `Promedio de Reviews: ${analyticData.averageReviews}`,
          margin: [0, 0, 0, 15]
        },
        {
          text: `Ganancias Totales: ${analyticData.totalGains}`,
          margin: [0, 0, 0, 15]
        }
      ],
      styles: {
        sectionHeader: {
          bold: true,
          decoration: 'underline',
          fontSize: 14,
          margin: [0, 15, 0, 15]
        }
      }
    };

    const pdf = pdfMake.createPdf(docDefinition);
    pdf.open();
  }

  generatePDF(action: InvoiceAction = InvoiceAction.VIEW, invoice: OrderResponse) {
    const warranty = invoice.details.find(x => x.warranty !== null).warranty;
    const products: PurchaseOrderOptionResponse[] = invoice.details.map(x => x.purchaseOptions).flat();
    console.log(invoice)
    const total = products.reduce((sum, p) => sum + (p.quantity * p.unitPrice), 0).toFixed(2);

    let docDefinition = {
      content: [
        {
          text: 'RosaFiesta',
          fontSize: 20,
          alignment: 'center',
        },
        {
          text: 'Factura',
          fontSize: 16,
          bold: true,
          alignment: 'center',
          decoration: 'underline'
        },
        {
          text: 'Detalles del Cliente ',
          style: 'sectionHeader'
        },
        {
          columns: [
            [
              {
                text: `Nombre completo: ${invoice.address.customerName}`,
                bold: true
              },
              {text: `Dirección de envío: ${invoice.address.address}`},
              {text: `Codigo Postal: ${invoice.address.postalCode}`},
              {text: `Correo: ${invoice.address.email}`},
              {text: `Codigo de Transacción: ${invoice.transactionId}`},
              {text: `Telefono: ${invoice.address.phoneNumber}`}
            ],
            [
              {
                text: `Fecha: ${invoice.transactionDate}`,
                alignment: 'right'
              },
              {
                text: `Codigo de Orden: ${invoice.orderId}`,
                alignment: 'right'
              },
              {
                text: `Medio de Pago: Paypal`,
                alignment: 'right'
              },
              {
                text: `Estado de la Orden: ${invoice.status}`,
                alignment: 'right'
              }
            ]
          ]
        },
        {
          text: 'Detalles de la Orden',
          style: 'sectionHeader'
        },
        {
          table: {
            headerRows: 1,
            widths: ['*', 'auto', 'auto', 'auto'],
            body: [

              ['Producto', 'Precio', 'Cantidad', 'Monto'],
              ...products.map(p => ([p.title, `$${p.unitPrice}`, `$${p.quantity}`, `$${(p.unitPrice * p.quantity).toFixed(2)}`])),
              [{text: 'ITBIS', colSpan: 3}, {}, {}, `$${invoice.taxes}`],
              [{
                text: 'Costo de Envío',
                colSpan: 3
              }, {}, {}, `$${Math.max((invoice.shipping - invoice.shippingDiscount), 0)}`],
              [{text: 'Monto Total', colSpan: 3}, {}, {}, `$${total}`]
            ]
          }
        },
        {
          text: 'Detalles adicionales',
          style: 'sectionHeader'
        },
        {
          text: "Producto Comprado en RosaFiesta",
          margin: [0, 0, 0, 15]
        },
        {
          columns: [
            [{qr: `${config.clientURL}intranet/settings`, fit: '50'}],
            [{text: 'Firma', alignment: 'right', italics: true}],
          ]
        },
        {
          text: 'Terminos de la Garantía',
          style: 'sectionHeader'
        },
        {
          ul: [
            warranty !== null ? warranty.description :
              `No aplica.`
          ],
        }
      ],
      styles: {
        sectionHeader: {
          bold: true,
          decoration: 'underline',
          fontSize: 14,
          margin: [0, 15, 0, 15]
        }
      }
    };

    const pdf = pdfMake.createPdf(docDefinition);

    if (action === InvoiceAction.DOWNLOAD) {
      pdf.download();
    } else if (action === InvoiceAction.PRINT) {
      pdf.print();
    } else {
      pdf.open();
    }

  }

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
        let blob = new Blob([fileData], {type: 'application/octet-stream'});
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

  async UpdateFiles(files: any, optionId: number): Promise<MultipleImageDto[]> {
    if (files.length > 5)
      throw new Error('You cant upload more than 5 images');
    let filesToUpload: File[] = files;
    const formData = new FormData();
    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });
    const observable = this.http.put<MultipleImageDto[]>(`${this.apiUrl}updateFiles/options/${optionId}`, formData);
    return await lastValueFrom(observable);
  }

  async UploadFiles(files: any): Promise<MultipleImageDto[]> {
    if (files.length > 5)
      throw new Error('You cant upload more than 5 images');

    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });
    const observable = this.http.post<MultipleImageDto[]>(`${this.apiUrl}multiImages`, formData);
    return await lastValueFrom(observable);
  }
}
