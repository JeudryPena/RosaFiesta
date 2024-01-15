import {Component, Input, OnInit} from '@angular/core';
import {ProductPreviewResponse} from "@core/interfaces/Product/Response/productPreviewResponse";
import {WisheslistService} from "@intranet/services/wisheslist.service";
import {Router} from "@angular/router";
import {encrypt} from "@core/shared/util/util-encrypt";
import {SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ShareButtonsComponent} from "@core/shared/components/share-buttons/share-buttons.component";

@Component({
  selector: 'app-product-cards',
  templateUrl: './product-cards.component.html',
  styleUrl: './product-cards.component.sass'
})
export class ProductCardsComponent implements OnInit {
  @Input() products: ProductPreviewResponse[];
  swalOptions: SweetAlertOptions = {icon: 'info'};

  constructor(
    private readonly wishlistService: WisheslistService,
    private readonly router: Router,
    private readonly swalService: SwalService,
    private readonly modalService: NgbModal
  ) {
  }

  ngOnInit(): void {
    for (let product of this.products) {
      const data = {id: product.id};
      product.shareUrl = window.location.origin + '/products/detail?productId=' + encrypt(JSON.stringify({id: data}));
    }
  }

  productDetail(productId: string, optionId: string) {
    const data = {id: productId, optionId: optionId};
    const dataEncrypted = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/detail`], {queryParams: {product: dataEncrypted}});
  }

  shareButtons(shareUrl: string, productTitle: string) {
    const modalRef = this.modalService.open(ShareButtonsComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = 'Compartir Producto';
    modalRef.componentInstance.shareUrl = shareUrl;
    modalRef.componentInstance.productTitle = productTitle;
  }

  addToWishList(optionId: string) {
    this.wishlistService.addToWishList(optionId).subscribe({
      next: () => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha agregado el producto a la lista de deseos correctamente';
        this.swalOptions.title = 'Producto agregado';
        this.swalService.show(this.swalOptions);
      },
      error: (error) => {
        this.swalService.showErrors(error, {title: 'Error'});
      }
    });
  }
}