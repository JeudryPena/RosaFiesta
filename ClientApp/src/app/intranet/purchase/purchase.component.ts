import {AfterViewInit, Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import Swal, {SweetAlertOptions} from "sweetalert2";
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

export interface Address {
  description: string,
  postalCode: string,
  municipality: string,
  province: string
}

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.sass']
})
export class PurchaseComponent implements OnInit, AfterViewInit {

  stepperOrientation: Observable<StepperOrientation>;

  @ViewChild('address', {static: true}) addressElement: ElementRef;
  @ViewChild('paypal', {static: true}) paypalElement: ElementRef;

  totalItems: number = 0;
  totalPrice: number = 0;
  totalWeight: number = 0;
  itbis: number = 0;
  taxMetter = 1.5;
  sendPrice: number = 0;
  details: PurchaseDetailResponse[] = [];
  businessDirection: google.maps.LatLngLiteral = {lat: 18.408969038725395, lng: -70.10919130614657};
  shippingDiscount: number = 0;

  firstStepForm: FormGroup;
  secondStepForm: FormGroup;
  thirdStepForm: FormGroup;
  swalOptions: SweetAlertOptions = {icon: 'info'};
  autocomplete: google.maps.places.Autocomplete | undefined;

  config = {
    onCompleteAuthorization: (authorization: string) => {
      this.completePurchase(authorization);
    }
  };
  protected readonly Math = Math;

  constructor(
    public modalService: NgbModal,
    private readonly breakpointObserver: BreakpointObserver,
    private readonly fb: FormBuilder,
    private discountService: DiscountsService,
    private router: Router,
    private service: CartsService,
    private warrantyService: WarrantiesService,
    private purchaseService: PurchaseService,
    private authenticateService: AuthenticateService,
  ) {
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({matches}) => (matches ? 'horizontal' : 'vertical')));
  }

  ngAfterViewInit(): void {
    google.maps.importLibrary('places').then(() => {
      this.autocomplete = new google.maps.places.Autocomplete(this.addressElement.nativeElement, {
        componentRestrictions: {country: "DO"},
        types: ['establishment']
      });
      this.autocomplete.addListener("place_changed", async () => {
        const place = this.autocomplete?.getPlace();
        let zipCode = "";
        let province = "";
        let municipality = "";
        const municipalityTypes = ["locality", "sublocality", "sublocality_level_1", "sublocality_level_2"];
        for (let j = 0; j < place.address_components.length; j++) {
          if (place.address_components[j].types[0] == 'postal_code') {
            zipCode = place.address_components[j].short_name;
          }
          for (let k = 0; k < place.address_components[j].types.length; k++) {
            const type = place.address_components[j].types[k];
            if (type == 'administrative_area_level_1') {
              if (place.address_components[j].long_name != "Distrito Nacional" && place.address_components[j].long_name != "Santo Domingo")
                province = "Distrito Nacional (Santo Domingo)";
              else
                province = place.address_components[j].long_name;
            } else if (municipalityTypes.includes(type)) {
              municipality = place.address_components[j].long_name;
            }
          }
        }
        const sendDirection: google.maps.LatLngLiteral = {
          lat: place.geometry.location.lat(),
          lng: place.geometry.location.lng()
        }
        google.maps.importLibrary('geometry').then(async () => {
          const distance = google.maps.geometry.spherical.computeDistanceBetween(
            sendDirection,
            this.businessDirection
          );
          this.sendPrice = (distance * 0.001) * this.taxMetter;
          if (distance < 4000) {
            this.shippingDiscount = Math.max((this.totalPrice * 0.25), 0);
          } else {
            this.shippingDiscount = 0;
          }

          this.firstStepForm.setValue({
            description: place.name,
            postalCode: zipCode,
            municipality: municipality,
            province: province
          });
          await this.initConfig();
        });
      })
    });
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
      shippingDiscount: order.purchase_units[0].amount.breakdown.shipping_discount.value,
      taxes: order.purchase_units[0].amount.breakdown.tax_total.value,
      transactionDate: order.create_time
    }

    this.purchaseService.purchase(orderDto).subscribe({
      next: (response) => {
        Swal.fire({
          icon: 'success',
          title: 'Pago procesado correctamente',
          text: 'Gracias por su compra, en breve recibirá un correo con los detalles de su compra, puede revisar el estado de su compra en la sección de mis ordenes'
        }).then((result) => {
          this.router.navigate(['/intranet/settings']);
        })
        this.service.updatedCart();
      },
      error: (err) => {
        Swal.fire({
          icon: 'error',
          title: 'Error al procesar el pago',
          text: 'Ocurrió un error al procesar el pago, por favor intente de nuevo'
        })
        console.error(err);
      }
    })
  }

  ngOnInit(): void {
    this.initForms();
    this.getCartItems();
  }

  async initConfig() {

    const addressValue = this.firstStepForm.value;

    const addressDto: Address = {
      description: addressValue.description,
      postalCode: addressValue.postalCode,
      municipality: addressValue.municipality,
      province: addressValue.province
    }

    let items: any[] = [];
    for (let detail of this.details) {
      for (let option of detail.purchaseOptions) {
        const value = option.option.offerPrice ? option.option.offerPrice : option.option.price;
        const item: any = {
          name: option.option.title,
          quantity: option.quantity.toString(),
          category: "PHYSICAL_GOODS",
          unit_amount: {
            currency_code: 'USD',
            value: `${value.toFixed(2)}`,
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
          application_context: {
            shipping_preference: 'SET_PROVIDED_ADDRESS'
          },
          payer: {
            email_address: `${user.email}`,
            address: {
              address_line_2: addressDto.description,
              admin_area_2: addressDto.municipality,
              postal_code: addressDto.postalCode,
              country_code: 'DO'
            }
          },
          purchase_units: [{
            amount: {
              currency_code: 'USD',
              value: `${(this.totalPrice + (Math.max((this.sendPrice - this.shippingDiscount), 0)) + this.itbis).toFixed(2)}`,
              breakdown: {
                item_total: {
                  currency_code: 'USD',
                  value: `${(this.totalPrice).toFixed(2)}`
                },
                shipping: {
                  currency_code: 'USD',
                  value: `${(this.sendPrice).toFixed(2)}`
                },
                tax_total: {
                  currency_code: 'USD',
                  value: `${(this.itbis).toFixed(2)}`
                },
                shipping_discount: {
                  currency_code: 'USD',
                  value: `${(this.shippingDiscount).toFixed(2)}`
                }
              }
            },
            shipping: {
              address: {
                address_line_2: addressDto.description,
                admin_area_2: addressDto.municipality,
                postal_code: addressDto.postalCode,
                country_code: 'DO',
                email: `${user.email}`
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
          let totalWeight = 0;
          for (let element of response.details) {
            for (let detail of element.purchaseOptions) {
              const discountResponse = this.discountService.GetOptionDiscount(detail.optionId);
              const discount = await lastValueFrom(discountResponse);
              totalItems += detail.quantity;
              if (discount != null) {
                detail.option.offerPrice = detail.option.price - (detail.option.price * (discount.value / 100));
                detail.option.discountValue = discount.value;
                totalPrice += detail.option.offerPrice * detail.quantity;
                totalWeight += detail.option.weight * detail.quantity;
              } else {
                totalPrice += detail.option.price * detail.quantity;
                totalWeight += detail.option.weight * detail.quantity;
              }
            }
            if (element.warrantyId) {
              const warrantyResponse = this.warrantyService.GetWarranty(element.warrantyId);
              element.warranty = await lastValueFrom(warrantyResponse);
            }
          }

          this.totalItems = totalItems;
          this.totalPrice = totalPrice;
          this.totalWeight = totalWeight;
          this.itbis = totalPrice * 0.18;
          this.details = response.details;
        } else {
          Swal.fire({
            icon: 'error',
            title: 'No tienes productos en el carrito',
            text: 'No tienes productos en el carrito, por favor agrega productos para continuar con el proceso de compra'
          }).then((result) => {
            this.router.navigate(['/main-page/home']);
          });
        }
      }, error: (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error al obtener el carrito',
          text: 'Ocurrió un error al obtener el carrito, por favor intente de nuevo'
        });
        console.error(error);
      }
    });
  }

  private initForms() {
    this.firstStepForm = this.fb.group({
      description: new FormControl('', [Validators.required]),
      postalCode: new FormControl('', [Validators.required]),
      municipality: "",
      province: "",
    })
    this.secondStepForm = this.fb.group({
      detailsConfirmed: new FormControl(false, [Validators.required])
    })
    this.thirdStepForm = this.fb.group({
      paymentConfirmed: new FormControl(false, [Validators.required])
    })
  }
}
