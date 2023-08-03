import { DecimalPipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { ManagementProductsResponse } from '../../interfaces/Product/Response/managementProductsResponse';
import { AuthenticateService } from '../../shared/services/authenticate.service';
import { ProductsService } from '../../shared/services/products.service';
import { CartsService } from '../../shared/services/carts.service';
import { CartResponse } from '../../interfaces/Product/Response/cartResponse';
import { PurchaseDetailResponse } from '../../interfaces/Product/UserInteract/Response/purchaseDetailResponse';
import { PurchaseDetailOptionResponse } from '../../interfaces/Product/UserInteract/Response/purchaseDetailOptionResponse';
import { Router } from '@angular/router';

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
  @Input() totalItems: number = 0;

  @Output() total: EventEmitter<number> = new EventEmitter<number>();

  ngOnInit(): void {
    this.getCartItems();
  }

  constructor(
    private service: CartsService,
    public modalService: NgbModal,
    private router: Router,
  ) {
    
    
  }

  purchase() {
    this.router.navigate(['/purchase']);
  }

  getCartItems() {
    console.log("tuhna")
    this.service.getMyCart().subscribe((response: CartResponse) => {
      if (response.details) {
        this.viewCart = true;
        response.details.forEach(element => {
          element.purchaseOptions.forEach(detail => {
            this.details.push(detail);
            this.totalItems += detail.quantity;
            this.totalPrice += detail.option.price * detail.quantity;
          });
        });
        this.total.emit(this.totalItems);
      }
    });
  }

  OnQuantityChange(event: any, detailId: string, optionId: string) { 
    const quantity = event.target.value;
    this.service.UpdateQuantity(quantity, detailId, optionId).subscribe({
      next: (response: any) => {
        this.details.forEach(element => {
          if (element.detailId == detailId && element.optionId == optionId) {
            element.quantity = quantity;
          }
        });
        this.totalCart();
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  deleteItem(detailId: string, optionId: string) {
    this.service.RemoveItem(detailId, optionId).subscribe({
      next: (response: any) => {
        this.details.forEach((element, index) => {
          if (element.detailId == detailId && element.optionId == optionId) {
            this.details.splice(index, 1);
          }
        });
        this.totalCart();
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  totalCart() {
    let total: number = 0;
    this.totalPrice = 0;
    this.details.forEach(element => {
      this.totalPrice += element.option.price * element.quantity;
      total += element.quantity;
    });
    console.log(total)
    this.total.emit(total);
  }

  clearCart() {
    this.service.ClearCart().subscribe({
      next: (response: any) => {
        this.details = [];
        this.totalPrice = 0;
        this.totalItems = 0;
        this.total.emit(this.totalItems);
      }, error: (error) => {
        console.log(error);
      }
    });
  }
}
