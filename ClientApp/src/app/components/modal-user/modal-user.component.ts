import { Component, ElementRef, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { RolesListResponse } from '../../interfaces/Security/Response/rolesListResponse';
import { UserForCreationDto } from '../../interfaces/Security/userForCreationDto';
import { UsersService } from '../../shared/services/users.service';

@Component({
  selector: 'app-modal-user',
  templateUrl: './modal-user.component.html',
  styleUrls: ['./modal-user.component.scss']
})
export class ModalUserComponent {

  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() id: string = '';

  userForm: any;
  roles: any[] = [];
  selected?: string;
  updateRole = false;
  roleTitle = '';
  rolesList: RolesListResponse[] = [];

  userNameFocused = false;
  emailFocused = false;
  passwordFocused = false;
  confirmPasswordFocused = false;
  birthDateFocused = false;
  nameFocused = false;
  lastNameFocused = false;
  roleIdFocused = false;
  promotionalMailsFocused = false;

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: UsersService,
    public el: ElementRef
  ) {
  }

  onSelect(event: TypeaheadMatch): void {
    this.roles.push({
      id: event.item.id,
      name: event.item.name
    });
    this.selected = '';
  }

  ngOnInit(): void {
    this.userForm = new FormGroup({
      userName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl(''),
      birthDate: new FormControl(''),
      name: new FormControl(''),
      lastName: new FormControl(''),
      roleId: new FormControl(''),
      promotionalMails: new FormControl(false),
    });
    if (this.update) {
      // this.service.GetManagement(this.id).subscribe((response: ManagementUsersResponse) => {
      //   this.usersForm.patchValue({
      //     userName: response.userName,
      //     email: response.email,
          
      //   });

      //   this.products = response.products || [];
      // });
    } else if (this.read) {
      // this.supplierForm = new FormGroup({
      //   name: new FormControl(''),
      //   email: new FormControl(''),
      //   phone: new FormControl(''),
      //   description: new FormControl(''),
      //   address: new FormControl(''),
      //   products: new FormControl(''),
      //   createdAt: new FormControl(''),
      //   createdBy: new FormControl(''),
      //   updatedAt: new FormControl(''),
      //   updatedBy: new FormControl('')
      // })

      // this.service.GetManagement(this.id).subscribe((response: SupplierResponse) => {

      //   this.supplierForm.patchValue({
      //     name: response.name,
      //     email: response.email,
      //     phone: response.phone,
      //     description: response.description,
      //     address: response.address,
      //     createdAt: response.createdAt,
      //     createdBy: response.createdBy,
      //     updatedAt: response.updatedAt,
      //     updatedBy: response.updatedBy,
      //   });

      //   this.products = response.products || [];
      // });
    }

    this.service.GetRolesList().subscribe({
      next: (response: RolesListResponse[]) => {
        this.rolesList = response;
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.userForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  removeRoles(index: number) {
    this.roles.splice(index, 1);
  }

  updateUser = (userFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea actualizar el usuario?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const user = { ...userFormValue };
        const UserForCreationDto: UserForCreationDto = {
          userName: user.userName,
          email: user.email,
          password: user.password,
          confirmPassword: user.confirmPassword,
          birthDate: user.birthDate,
          name: user.name,
          lastName: user.lastName,
          roleId: user.roleId,
          promotionalMails: user.promotionalMails,                    
        }
        this.service.Update(this.id, UserForCreationDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Usuario actualizado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.activeModal.close(true);
            });
          }, error: (error) => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

  Add = (userFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea guardar el usuario?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const user = { ...userFormValue };

        const UserForCreationDto: UserForCreationDto = {
          userName: user.name,
          email: user.email,
          password: user.password,
          confirmPassword: user.confirmPassword,
          birthDate: user.birthDate,
          name: user.name,
          lastName: user.lastName,
          roleId: user.roleId,
          promotionalMails: user.promotionalMails,
        }

        this.service.Add(UserForCreationDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Usuario guardado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
              this.activeModal.close(true);
            });
          }, error: (error) => {
            console.log(error);
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

}
