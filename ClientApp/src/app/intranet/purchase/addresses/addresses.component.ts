import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {AddressesService} from "@intranet/services/addresses.service";
import {AddressDto} from "@core/interfaces/Security/addressDto";
import {SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {BehaviorSubject, lastValueFrom} from "rxjs";
import {AddressResponse} from "@core/interfaces/Security/Response/addressResponse";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-addresses',
  templateUrl: './addresses.component.html',
  styleUrls: ['./addresses.component.sass']
})
export class AddressesComponent implements OnInit {

  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() id: string = '';
  addressForm$: BehaviorSubject<FormGroup | null> = new BehaviorSubject<FormGroup | null>(null);
  swalOptions: SweetAlertOptions = {icon: 'info'};

  constructor(
    private readonly addressService: AddressesService,
    private readonly swalService: SwalService,
    private readonly activeModal: NgbActiveModal,
    private readonly fb: FormBuilder,
    private readonly datePipe: DatePipe
  ) {

  }

  onCreate() {
    this.addressForm$.next(this.fb.group({
      title: new FormControl(''),
      phoneNumber: new FormControl(''),
      name: new FormControl(''),
      lastName: new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      zipCode: new FormControl(''),
      extraDetails: new FormControl(''),
    }));
  }

  onEdit() {
    const address$ = this.addressService.retrieveById(this.id);
    let addressResponse: Promise<AddressResponse> = lastValueFrom(address$);
    addressResponse.catch((error) => {
      this.swalService.error();
      this.activeModal.close();
      console.error(error);
    });
    addressResponse.then((response) => {
      const form = this.fb.group({
        title: new FormControl(response.title),
        phoneNumber: new FormControl(response.phoneNumber),
        name: new FormControl(''),
        lastName: new FormControl(''),
        city: new FormControl(response.city),
        state: new FormControl(response.state),
        zipCode: new FormControl(response.zipCode),
        extraDetails: new FormControl(response.extraDetails)
      });

      let splitName = response.fullName.split(' ');

      let firstName = splitName.slice(0, (splitName.length / 2)).join(' ');
      let lastName = splitName.slice((splitName.length / 2)).join(' ');
      form.patchValue({
        name: firstName,
        lastName: lastName
      });

      this.addressForm$.next(form);
    });
  }

  onRead() {
    const address$ = this.addressService.retrieveById(this.id);
    let addressResponse: Promise<AddressResponse> = lastValueFrom(address$);
    addressResponse.catch((error) => {
      this.swalService.error();
      this.activeModal.close();
      console.error(error);
    });
    addressResponse.then((response) => {

      const addressForm = this.fb.group({
        title: new FormControl(response.title),
        phoneNumber: new FormControl(response.phoneNumber),
        name: new FormControl(''),
        lastName: new FormControl(''),
        city: new FormControl(response.city),
        state: new FormControl(response.state),
        zipCode: new FormControl(response.zipCode),
        extraDetails: new FormControl(response.extraDetails),
        createdAt: this.datePipe.transform(response.createdAt, 'dd-MMM-yyyy h:mm:ss a'),
        updatedAt: this.datePipe.transform(response.updatedAt, 'dd-MMM-yyyy h:mm:ss a'),
      });
      let splitName = response.fullName.split(' ');

      let firstName = splitName.slice(0, (splitName.length / 2)).join(' ');
      let lastName = splitName.slice((splitName.length / 2)).join(' ');
      addressForm.patchValue({
        name: firstName,
        lastName: lastName
      });
      addressForm.disable();
      this.addressForm$.next(addressForm);
    });
  }

  ngOnInit(): void {
    if (!this.update && !this.read) {
      this.onCreate();
    } else if (this.update) {
      this.onEdit();
    } else if (this.read) {
      this.onRead();
    }
  }

  validate = (controlName: string, errorName: string) => {
    const addressForm = this.addressForm$.getValue();
    const control = addressForm.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  completeForm(formValue: any) {
    const form = {...formValue}
    const address: AddressDto = {
      title: form.title,
      phoneNumber: form.phoneNumber.replace(/[^0-9]/g, ""),
      name: form.name,
      lastName: form.lastName,
      city: form.city,
      state: form.state,
      zipCode: form.zipCode,
      extraDetails: form.extraDetails
    }

    if (this.update)
      this.updateForm(address);
    else
      this.addForm(address);
  }

  updateForm(address: AddressDto) {
    this.addressService.update(address, this.id).subscribe({
      next: (response) => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha actualizado la dirección correctamente';
        this.swalOptions.title = 'Dirección actualizada';
        this.swalService.show(this.swalOptions);
        this.activeModal.close(true);
      },
      error: (error) => {
        this.swalService.error();
        console.error(error);
        this.activeModal.close();
      }
    })
  }

  addForm(address: any) {
    this.addressService.persist(address).subscribe({
      next: (response) => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha agregado la dirección correctamente';
        this.swalOptions.title = 'Dirección agregada';
        this.swalService.show(this.swalOptions);
        this.activeModal.close(true);
      },
      error: (error) => {
        this.swalService.error();
        console.error(error);
        this.activeModal.close();
      }
    })
  }

  closeModal() {
    this.activeModal.close();
  }
}
