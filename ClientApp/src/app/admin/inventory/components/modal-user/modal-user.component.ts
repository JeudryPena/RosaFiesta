import {DatePipe} from '@angular/common';
import {Component, ElementRef, Input, ViewChild} from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {RolesListResponse} from '@core/interfaces/Security/Response/rolesListResponse';
import {UserResponse} from '@core/interfaces/Security/Response/userResponse';
import {UserForCreationDto} from '@core/interfaces/Security/userForCreationDto';
import {UsersService} from '../../services/users.service';
import {BehaviorSubject, lastValueFrom} from "rxjs";

@Component({
  selector: 'app-modal-user',
  templateUrl: './modal-user.component.html',
  styleUrls: ['./modal-user.component.sass']
})
export class ModalUserComponent {

  @ViewChild('moduleInput') moduleInput!: ElementRef;

  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() id: string = '';

  minDate!: Date;
  maxDate!: Date;
  date!: Date;

  userForm$: BehaviorSubject<FormGroup | null> = new BehaviorSubject<FormGroup | null>(null);
  roles: any[] = [];
  rolesList: RolesListResponse[] = [];

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: UsersService,
    public el: ElementRef,
    private fb: FormBuilder,
    private readonly datePipe: DatePipe
  ) {
  }

  onSelect(user: any): void {
    this.roles.push({
      roleId: user.id,
      name: user.name
    });
  }

  onCreate() {
    this.maxDate.setDate(this.minDate.getDate() + 3648);
    this.maxDate.setHours(this.maxDate.getHours(), this.maxDate.getMinutes(), this.maxDate.getSeconds() + 1);
    const relationsResponse = this.relationLists();
    relationsResponse.then((response) => {
      this.rolesList = response || [];
    });
    this.userForm$.next(this.fb.group({
      userName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl(''),
      birthDate: new FormControl(''),
      userRoles: new FormControl(''),
      promotionalMails: new FormControl(false)
    }));
  }

  onEdit() {
    const user$ = this.service.GetManagement(this.id);
    let userResponse: Promise<UserResponse> = lastValueFrom(user$);
    userResponse.catch((error) => {
      console.error(error);
    });
    let relationsResponse: Promise<RolesListResponse[]> = this.relationLists();

    Promise.all([userResponse, relationsResponse]).then(([userResponse, relationsResponse]) => {
      this.rolesList = relationsResponse || [];
      this.userForm$.next(this.fb.group({
        userName: new FormControl(userResponse.userName),
        email: new FormControl(userResponse.email),
        password: new FormControl(''),
        confirmPassword: new FormControl(''),
        birthDate: new FormControl(userResponse.birthDate),
        userRoles: new FormControl(''),
        promotionalMails: new FormControl(userResponse.promotionalMails)
      }));
    });
  }

  onRead() {
    const user$ = this.service.GetManagement(this.id);
    let userResponse: Promise<UserResponse> = lastValueFrom(user$);
    userResponse.catch((error) => {
      console.error(error);
    });
    let relationsResponse: Promise<RolesListResponse[]> = this.relationLists();

    Promise.all([userResponse, relationsResponse]).then(([userResponse, relationsResponse]) => {
      this.rolesList = relationsResponse || [];
      const userForm = this.fb.group({
        userName: new FormControl(userResponse.userName),
        email: new FormControl(userResponse.email),
        password: new FormControl(''),
        confirmPassword: new FormControl(''),
        birthDate: new FormControl(userResponse.birthDate),
        userRoles: new FormControl(''),
        promotionalMails: new FormControl(userResponse.promotionalMails),
        createdAt: this.datePipe.transform(userResponse.createdAt, 'dd-MMM-yyyy h:mm:ss a'),
        updatedAt: this.datePipe.transform(userResponse.updatedAt, 'dd-MMM-yyyy h:mm:ss a'),
        createdBy: userResponse.createdBy,
        updatedBy: userResponse.updatedBy,
      });
      userForm.disable();
      this.userForm$.next(userForm);
    });
  }

  ngOnInit(): void {
    this.minDate = new Date();
    this.maxDate = new Date();
    this.minDate.setDate(this.minDate.getDate() - 47450)

    if (!this.update && !this.read) {
      this.onCreate();
    } else if (this.update) {
      this.onEdit();
    } else if (this.read) {
      this.onRead();
    }
  }

  relationLists() {
    const response$ = this.service.GetRolesList();
    const response = lastValueFrom(response$);
    response.catch((error) => {
      console.error(error);
    });
    return response;
  }

  validate = (controlName: string, errorName: string) => {
    const form = this.userForm$.value;
    const control = form.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  removeRoles(index: number) {
    this.roles.splice(index, 1);
  }

  updateUser = (userFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea actualizar el Usuario?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const user = {...userFormValue};
        const birthDate = new DatePipe('en-US');
        const birthDateValue = birthDate.transform(user.birthDate, 'yyyy-MM-dd')
        const UserForUpdateDto: UserForCreationDto = {
          userName: user.userName,
          email: user.email,
          password: user.password,
          confirmPassword: user.confirmPassword,
          birthDate: birthDateValue,
          rolesId: this.roles,
          promotionalMails: user.promotionalMails,
        }
        this.service.Update(this.id, UserForUpdateDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Usuario actualizado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.activeModal.close(true);
            });
          }, error: (error) => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

  Add = (userFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea guardar el usuario?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const user = {...userFormValue};
        const birthDate = new DatePipe('en-US');
        const birthDateValue = birthDate.transform(user.birthDate, 'yyyy-MM-dd')
        const UserForCreationDto: UserForCreationDto = {
          userName: user.userName,
          email: user.email,
          password: user.password,
          confirmPassword: user.confirmPassword,
          birthDate: birthDateValue,
          rolesId: this.roles,
          promotionalMails: user.promotionalMails,
        }


        this.service.Add(UserForCreationDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Usuario guardado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
              this.activeModal.close(true);
            });
          }, error: (error) => {
            console.error(error);
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

}
