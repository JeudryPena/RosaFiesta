import {Component, Input, OnInit} from '@angular/core';
import {ProductDetailResponse} from "@core/interfaces/Product/Response/productDetailResponse";
import {FormControl, FormGroup} from "@angular/forms";
import {PurchaseDetailDto} from "@core/interfaces/Product/UserInteract/purchaseDetailDto";
import {CartsService} from "@intranet/services/carts.service";
import {Router} from "@angular/router";
import {encrypt} from "@core/shared/util/util-encrypt";
import {ShareButtonsComponent} from "@core/shared/components/share-buttons/share-buttons.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {WisheslistService} from "@intranet/services/wisheslist.service";
import {SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";

@Component({
  selector: 'app-product-details-top',
  templateUrl: './product-details-top.component.html',
  styleUrl: './product-details-top.component.sass'
})
export class ProductDetailsTopComponent implements OnInit {
  cartForm!: FormGroup;

  swalOptions: SweetAlertOptions = {icon: 'info'};

  @Input() product: ProductDetailResponse;
  @Input() isAuthenticated = false;

  constructor(
    private readonly cartService: CartsService,
    private readonly router: Router,
    private readonly modalService: NgbModal,
    private readonly wishlistService: WisheslistService,
    private readonly swalService: SwalService,
  ) {

  }

  buyNow(cartFormValue: any) {
    this.cartSubmit(cartFormValue)
    this.router.navigate(['/purchase']);
  }

  productDetail(productId: string, optionId: string) {
    const data = {id: productId, optionId: optionId};
    const dataEncrypted = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/detail`], {queryParams: {product: dataEncrypted}}).then(
      () => {
        window.location.reload();
      }
    )
  }

  shareButtons(productTitle: string, productId: string) {
    const data = {id: productId};
    const shareUrl = window.location.origin + '/products/detail?productId=' + encrypt(JSON.stringify({id: data}));
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

  ngOnInit(): void {
    this.cartForm = new FormGroup({
      quantity: new FormControl(1)
    });
  }

  AddToCart(cartFormValue: any) {
    this.cartSubmit(cartFormValue)
  }

  cartSubmit(cartFormValue: any) {
    const cart = {...cartFormValue};

    const cartDto: PurchaseDetailDto = {
      productId: this.product.id,
      quantity: cart.quantity,
      optionId: this.product.optionId
    }
    console.log(cartDto)
    this.cartService.AddProductToCart(cartDto).subscribe({
      next: () => {
        this.router.navigate(['']);
      }, error: (err) => {
        console.error(err);
      }
    });
  }

}
