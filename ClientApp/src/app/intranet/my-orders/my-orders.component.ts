import {Component, OnInit, ViewChild} from '@angular/core';
import {PurchaseService} from "@intranet/services/purchase.service";
import {OrderPreviewResponse} from "@core/interfaces/Product/Response/orderPreviewResponse";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from "@angular/material/sort";
import Swal from "sweetalert2";
import {InvoiceAction} from "@core/interfaces/invoice";
import {OrderResponse} from "@core/interfaces/Product/UserInteract/Response/orderResponse";
import {FilesService} from "@core/shared/services/files.service";

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.scss']
})
export class MyOrdersComponent implements OnInit {
  dataSource: MatTableDataSource<OrderPreviewResponse> = new MatTableDataSource<OrderPreviewResponse>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filesTbSort') filesTbSort = new MatSort();
  displayedColumns: string[] = ['orderId', 'total', 'transactionDate', 'status', 'actions'];

  invoiceAction = InvoiceAction;

  constructor(
    private readonly purchaseService: PurchaseService,
    private readonly fileService: FilesService
  ) {
  }

  ngOnInit(): void {
    this.retrieveData()
  }

  invoice(invoiceAction: InvoiceAction, id: string) {
    this.purchaseService.retrieveOrderDetail(id).subscribe({
      next: (order: OrderResponse) => {
        this.fileService.generatePDF(invoiceAction, order);
      },
      error: (error) => {
        Swal.fire({
          title: 'No se pudo obtener los datos',
          icon: 'error',
          text: 'No se pudo obtener los datos'
        })
        console.error(error);
      }
    });
  }

  requestRefund(id: string) {
    this.purchaseService.requestRefund(id).subscribe({
      next: (data: boolean) => {
        Swal.fire({
          title: data ? 'Solicitud de reembolso enviada' : 'No se pudo enviar la solicitud de reembolso',
          icon: data ? 'success' : 'error',
          text: data ? 'Se ha enviado la solicitud de reembolso correctamente' : 'Su compra ya excedio el tiempo para solicitar un reembolso'
        }).then(() => {
          this.retrieveData()
        });
      },
      error: (error) => {
        Swal.fire({
          title: 'No se pudo enviar la solicitud de reembolso',
          icon: 'error',
          text: 'No se pudo enviar la solicitud de reembolso'
        })
        console.error(error);
      }
    });
  }

  retrieveData() {
    this.purchaseService.retrieveMyOrders().subscribe({
      next: (data) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.filesTbSort;
      },
      error: (error) => {
        Swal.fire({
          title: 'No se pudo obtener los datos',
          icon: 'error',
          text: 'No se pudo obtener los datos'
        });
        console.error(error);
      }
    });
  }
}
