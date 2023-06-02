import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductAndOptionsPreviewResponse } from '../../interfaces/product/response/productAndOptionsPreviewResponse';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { ProductsService } from '../../shared/services/products.service';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class CartComponent {
  viewCart: boolean = false;
  products$: Observable<ProductAndOptionsPreviewResponse[]>;
  total$: Observable<number>;

  constructor(
    public service: ProductsService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) { 
    this.products$ = service.products$;
    this.total$ = service.total$;
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
