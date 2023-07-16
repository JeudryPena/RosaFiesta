import { DecimalPipe } from '@angular/common';
import { Component } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { ManagementProductsResponse } from '../../interfaces/Product/Response/managementProductsResponse';
import { AuthenticateService } from '../../shared/services/authenticate.service';
import { ProductsService } from '../../shared/services/products.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class CartComponent {
  viewCart: boolean = false;
  products$: Observable<ManagementProductsResponse[]> = new Observable<ManagementProductsResponse[]>();
  total$: Observable<number> = new Observable<number>();
  isUserAuthenticated: boolean = false;

  constructor(
    public service: ProductsService,
    public modalService: NgbModal,
    config: NgbModalConfig,
    private authService: AuthenticateService
  ) {

    // this.authService.authChanged
    //   .subscribe(res => {
    //     this.isUserAuthenticated = res;
    //   })
  }



  updateUnits(operation: string, id: string) {



  }

  totalProduct(price: number, units: number) {
    return price * units
  }

  deleteProduct(id: string) {


  }

  totalCart() {

  }
}
