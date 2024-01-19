import {Component, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ICreateOrderRequest, IPayPalConfig, ITransactionItem} from 'ngx-paypal';
import {AddressesComponent} from './addresses/addresses.component';
import {config} from "@env/config.dev";
import {AddressPreviewResponse} from "@core/interfaces/Security/Response/addressPreviewResponse";
import {AddressesService} from "@intranet/services/addresses.service";
import {SwalConfirmItem, SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";
import {BehaviorSubject, lastValueFrom, map, Observable} from "rxjs";
import {BreakpointObserver} from '@angular/cdk/layout';
import {StepperOrientation} from '@angular/material/stepper';
import {MatTableDataSource} from "@angular/material/table";
import {DiscountsService} from "@admin/inventory/services/discounts.service";
import {CartsService} from "@intranet/services/carts.service";
import {Router} from "@angular/router";
import {CartResponse} from "@core/interfaces/Product/Response/cartResponse";
import {PurchaseDetailResponse} from "@core/interfaces/Product/UserInteract/Response/purchaseDetailResponse";
import {WarrantiesService} from "@admin/inventory/services/warranties.service";
import {PurchaseService} from "@intranet/services/purchase.service";
import {AuthenticateService} from "@auth/services/authenticate.service";


@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.sass']
})
export class PurchaseComponent implements OnInit {

  stepperOrientation: Observable<StepperOrientation>;

  @ViewChild('name') name: any;

  public confirmItem: SwalConfirmItem = {
    fnConfirm: this.deleteConfirm,
    confirmData: null,
    context: this
  };

  totalItems: number = 0;
  totalPrice: number = 0;
  sendPrice: number = 0;
  details: PurchaseDetailResponse[] = [];

  firstStepForm: FormGroup;
  secondStepForm: FormGroup;
  thirdStepForm: FormGroup;

  addresses: MatTableDataSource<AddressPreviewResponse> =
    new MatTableDataSource<AddressPreviewResponse>();

  paginatedAddresses$: Observable<AddressPreviewResponse[]>;

  swalOptions: SweetAlertOptions = {icon: 'info'};

  payPalConfig$: BehaviorSubject<IPayPalConfig | null> = new BehaviorSubject<IPayPalConfig | null>(null);

  constructor(
    public modalService: NgbModal,
    private readonly addressService: AddressesService,
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

  ngOnInit(): void {
    this.initForms();
    this.retrieveData();
  }

  createAddress() {
    const modalRef = this.modalService.open(AddressesComponent, {size: 'xl', scrollable: true});
    modalRef.componentInstance.title = 'Crear Dirección';
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  updateAddress(addressId: string) {
    const modalRef = this.modalService.open(AddressesComponent, {size: 'xl', scrollable: true});
    modalRef.componentInstance.title = 'Modificar Dirección';
    modalRef.componentInstance.id = addressId;
    modalRef.componentInstance.update = true;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  viewAddress(addressId: string) {
    const modalRef = this.modalService.open(AddressesComponent, {size: 'xl', scrollable: true});
    modalRef.componentInstance.title = 'Ver Dirección';
    modalRef.componentInstance.id = addressId;
    modalRef.componentInstance.read = true;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  deleteAddress(addressId: string) {
    this.swalOptions.icon = 'question';
    this.swalOptions.title = 'Eliminar Dirección de Envio';
    this.swalOptions.html = `Esta seguro de que desea eliminar la Dirección de Envio?`;
    this.swalOptions.showConfirmButton = true;
    this.swalOptions.showCancelButton = true;
    this.confirmItem.confirmData = addressId;
    this.confirmItem.fnConfirm = this.deleteConfirm;
    this.swalService.setConfirm(this.confirmItem);
    this.swalService.show(this.swalOptions);
  }

  public deleteConfirm(isConfirm: string, data: any, context: any): void {
    context.addressService.delete(data).subscribe({
      next: () => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha eliminado la dirección correctamente';
        this.swalOptions.title = 'Dirección eliminada';
        this.swalService.show(this.swalOptions);
        context.retrieveData();
        this.swalOptions.showCancelButton = false; //just need to show the OK button
        context.confirmItem.fnConfirm = null;//reset the confirm function to avoid call this function again and again.
        this.swalService.setConfirm(context.confirmItem);
      },
      error: (err) => {
        this.swalService.error();
        console.error(err);
      }
    });
  }

  selectAddress(selectedAddress: any) {
    this.firstStepForm.get('addressSelected').setValue(selectedAddress[0]);
  }

  applyFilter(event: any) {
    let filter = (event.target as HTMLInputElement).value;
    filter = filter.trim();
    filter = filter.toLowerCase();
    this.addresses.filter = filter;
  }

  retrieveData() {
    const response = this.addressService.retrieveAll();
    const address = lastValueFrom(response);
    address.catch(() => {
      this.swalService.error();
    });
    address.then((result: AddressPreviewResponse[]) => {
      this.getCartItems();
      this.addresses.data = result;
      this.addresses.filterPredicate = (data: AddressPreviewResponse, filter: string) => {
        const normalizedName = data.title
          .normalize('NFD')
          .replace(/[\u0300-\u036f]/g, '');
        const normalizedFilter = filter
          .normalize('NFD')
          .replace(/[\u0300-\u036f]/g, '');
        return normalizedName.toLowerCase().includes(normalizedFilter);
      };
      this.paginatedAddresses$ = this.addresses.connect();
    });
  }

  async completeAddressStep() {
    let items: ITransactionItem[] = [];
    for (let detail of this.details) {
      for (let option of detail.purchaseOptions) {
        const item: ITransactionItem = {
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

    let addressValue = this.firstStepForm.get('addressSelected')?.value;
    let addressResponse = this.addressService.retrieveById(addressValue);
    let address = await lastValueFrom(addressResponse);


    let userResponse = this.authenticateService.getCurrentDetailUser();
    let user = await lastValueFrom(userResponse);

    let splitName = address.fullName.split(' ');

    let firstName = splitName.slice(0, (splitName.length / 2)).join(' ');
    let lastName = splitName.slice((splitName.length / 2)).join(' ');

    this.payPalConfig$.next({
      currency: 'USD',
      clientId: config.payPalClientId,
      createOrderOnClient: (data: any) => <ICreateOrderRequest>{
        intent: 'CAPTURE',
        application_context: {
          shipping_preference: 'SET_PROVIDED_ADDRESS'
        },
        payer: {
          name: {
            given_name: `${firstName}`,
            surname: `${lastName}`
          },
          email_address: `${user.email}`,
          phone: {
            phone_type: "MOBILE",
            phone_number: {
              national_number: `${address.phoneNumber}`
            }
          },
          address: {
            
            postal_code: `${address.zipCode}`,
            country_code: "US"
          }
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
          shipping: {
            address: {
              address_line_1: "2211 N First Street",
              address_line_2: "Building 17",
              admin_area_2: "San Jose",
              admin_area_1: "CA",
              postal_code: "95131",
              country_code: "US"
            }
          },
          items: items
        }]
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
        actions.order.get().then((details: any) => {
          console.log('onApprove - you can get full order details inside onApprove: ', details);
          this.completePurchase();
        });
      },
      onClientAuthorization(authorization) {
        console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', authorization);

      },
      onCancel: (data: any, actions: any) => {
        console.log('OnCancel', data, actions);
      },
    });
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
                detail.option.offerPrice = detail.unitPrice - (detail.unitPrice * (discount.value / 100));
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
        }
      }, error: (error) => {
        this.swalService.error();
        console.error(error);
      }
    });
  }

  completePurchase() {
    this.purchaseService.purchase(this.firstStepForm.get('addressSelected')?.value).subscribe({
      next: (response) => {
        this.swalService.show({icon: 'success', title: 'Pago procesado correctamente'});
        this.router.navigate(['/intranet/my-orders']);
      },
      error: (err) => {
        this.swalService.error();
        console.error(err);
      }
    })
  }

  private initForms() {
    this.firstStepForm = this.fb.group({
      addressSelected: new FormControl(null, [Validators.required])
    })
    this.secondStepForm = this.fb.group({
      detailsConfirmed: new FormControl(false, [Validators.required])
    })
    this.thirdStepForm = this.fb.group({
      paymentConfirmed: new FormControl(false, [Validators.required])
    })
  }
}
