import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";
import {lastValueFrom, map, Observable} from "rxjs";
import {BreakpointObserver} from '@angular/cdk/layout';
import {StepperOrientation} from '@angular/material/stepper';
import {DiscountsService} from "@admin/inventory/services/discounts.service";
import {CartsService} from "@intranet/services/carts.service";
import {Router} from "@angular/router";
import {CartResponse} from "@core/interfaces/Product/Response/cartResponse";
import {PurchaseDetailResponse} from "@core/interfaces/Product/UserInteract/Response/purchaseDetailResponse";
import {WarrantiesService} from "@admin/inventory/services/warranties.service";
import {PurchaseService} from "@intranet/services/purchase.service";
import {AuthenticateService} from "@auth/services/authenticate.service";
import {OrderDto} from "@core/interfaces/Product/UserInteract/orderDto";

declare var paypal: any;

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.sass']
})
export class PurchaseComponent implements OnInit {

  stepperOrientation: Observable<StepperOrientation>;

  @ViewChild('paypal', {static: true}) paypalElement: ElementRef;

  totalItems: number = 0;
  totalPrice: number = 0;
  sendPrice: number = 0;
  details: PurchaseDetailResponse[] = [];

  firstStepForm: FormGroup;
  thirdStepForm: FormGroup;
  swalOptions: SweetAlertOptions = {icon: 'info'};

  config = {
    onCompleteAuthorization: (authorization: string) => {
      this.completePurchase(authorization);
    }
  };

  constructor(
    public modalService: NgbModal,
    private readonly swalService: SwalService,
    private readonly breakpointObserver: BreakpointObserver,
    private readonly fb: FormBuilder,
    private discountService: DiscountsService,
    private router: Router,
    private service: CartsService,
    private warrantyService: WarrantiesService,
    private purchaseService: PurchaseService,
    private authenticateService: AuthenticateService
  ) {
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({matches}) => (matches ? 'horizontal' : 'vertical')));
  }

  completePurchase(order: any) {
    const orderDto: OrderDto = {
      orderId: order.id,
      address: {
        countryCode: order.purchase_units[0].shipping.address.country_code,
        phoneNumber: order.payer.phone.phone_number.national_number,
        customerName: `${order.payer.name.given_name} ${order.payer.name.surname}`,
        address: order.purchase_units[0].shipping.address.address_line_1,
        description: order.purchase_units[0].shipping.address.address_line_2,
        location: `${order.purchase_units[0].shipping.address.admin_area_2}`,
        province: `${order.purchase_units[0].shipping.address.admin_area_1}`,
        postalCode: order.purchase_units[0].shipping.address.postal_code,
        email: order.payer.email_address
      },
      total: order.purchase_units[0].amount.value,
      transactionId: order.purchase_units[0].payments.captures[0].id,
      currencyCode: order.purchase_units[0].amount.currency_code,
      payerId: order.payer.payer_id,
      shipping: order.purchase_units[0].amount.breakdown.shipping.value,
      transactionDate: order.create_time
    }

    console.log(orderDto)

    this.purchaseService.purchase(orderDto).subscribe({
      next: (response) => {
        this.swalService.show({
          icon: 'success',
          title: 'Pago procesado correctamente',
          text: 'Gracias por su compra, en breve recibirá un correo con los detalles de su compra, puede revisar el estado de su compra en la sección de mis ordenes'
        });
        this.router.navigate(['/intranet/settings']);
        this.service.updatedCart();
      },
      error: (err) => {
        this.swalService.error();
        console.error(err);
      }
    })
  }

  ngOnInit(): void {
    this.initForms();
    this.getCartItems();
  }

  async initConfig() {
    let items: any[] = [];
    for (let detail of this.details) {
      for (let option of detail.purchaseOptions) {
        const item: any = {
          name: option.option.title,
          quantity: option.quantity.toString(),
          category: "PHYSICAL_GOODS",
          unit_amount: {
            currency_code: 'USD',
            value: `${option.option.offerPrice ? option.option.offerPrice : option.option.price}`,
          }
        }
        items.push(item);
      }
    }

    let userResponse = this.authenticateService.getCurrentDetailUser();
    let user = await lastValueFrom(userResponse);
    paypal.Buttons({
      createOrder: (data, actions) => {
        return actions.order.create({
          intent: 'CAPTURE',
          payer: {
            email_address: `${user.email}`
          },
          purchase_units: [{
            amount: {
              currency_code: 'USD',
              value: `${this.totalPrice + this.sendPrice}`,
              breakdown: {
                item_total: {
                  currency_code: 'USD',
                  value: `${this.totalPrice + this.sendPrice}`
                }
              }
            },
            items: items
          }]
        });
      },
      advanced: {
        commit: 'true'
      },
      style: {
        label: 'paypal',
        layout: 'vertical',
      },
      onApprove: (data: any, actions: any) => {
        console.log('onApprove - transaction was approved, but not authorized', data, actions);
        return actions.order.capture().then((order: any) => {
          if (order.status === 'COMPLETED') {
            console.log(order)
            this.completePurchase(order);
          }
        });
      },
      onClientAuthorization: (authorization) => {
        console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', authorization);
      },
      onError: err => {
        console.error(err);
      },
      onCancel: (data: any, actions: any) => {
        console.log('OnCancel', data, actions);
      },
    }).render(this.paypalElement.nativeElement);
  }

  getCartItems() {
    this.service.getMyCart().subscribe({
      next: async (response: CartResponse) => {
        if (response.details) {
          let totalItems = 0;
          let totalPrice = 0;
          for (let element of response.details) {
            for (let detail of element.purchaseOptions) {
              const discountResponse = this.discountService.GetOptionDiscount(detail.optionId);
              const discount = await lastValueFrom(discountResponse);
              totalItems += detail.quantity;
              if (discount != null) {
                detail.option.offerPrice = detail.option.price - (detail.option.price * (discount.value / 100));
                detail.option.discountValue = discount.value;
                totalPrice += detail.option.offerPrice * detail.quantity;
              } else {
                totalPrice += detail.option.price * detail.quantity;
              }
            }
            if (element.warrantyId) {
              const warrantyResponse = this.warrantyService.GetWarranty(element.warrantyId);
              element.warranty = await lastValueFrom(warrantyResponse);
            }
          }

          this.totalItems = totalItems;
          this.totalPrice = totalPrice;
          const sendPrice = totalItems * totalPrice * 0.05;
          if (sendPrice < 200)
            this.sendPrice = 0;
          else
            this.sendPrice = sendPrice;
          this.details = response.details;
          await this.initConfig();
        } else {
          this.swalService.show({icon: 'error', title: 'No tienes productos en el carrito'});
          this.router.navigate(['/main-page/home']);
        }
      }, error: (error) => {
        this.swalService.error();
        console.error(error);
      }
    });
  }

  private initForms() {
    this.firstStepForm = this.fb.group({
      detailsConfirmed: new FormControl(false, [Validators.required])
    })
    this.thirdStepForm = this.fb.group({
      paymentConfirmed: new FormControl(false, [Validators.required])
    })
  }
}
