import { DecimalPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { ManagementProductsResponse } from '../../interfaces/Product/Response/managementProductsResponse';
import { AuthenticateService } from '../../shared/services/authenticate.service';
import { ProductsService } from '../../shared/services/products.service';
import { CartsService } from '../../shared/services/carts.service';
import { CartResponse } from '../../interfaces/Product/Response/cartResponse';
import { PurchaseDetailResponse } from '../../interfaces/Product/UserInteract/Response/purchaseDetailResponse';
import { PurchaseDetailOptionResponse } from '../../interfaces/Product/UserInteract/Response/purchaseDetailOptionResponse';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class CartComponent implements OnInit {
  viewCart: boolean = false;
  details: PurchaseDetailOptionResponse[] = [];
  totalPrice: number = 0;

  ngOnInit(): void {
    this.service.getMyCart().subscribe((response: CartResponse) => {
      if (response.details) {
        this.viewCart = true;
        response.details.forEach(element => {
          element.purchaseOptions.forEach(detail => {
            this.details.push(detail);
            this.totalPrice += detail.quantity * detail.option.price;
          });
        });
      }
    });
      
    
  }

  constructor(
    private service: CartsService,
    public modalService: NgbModal
  ) {
    
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
