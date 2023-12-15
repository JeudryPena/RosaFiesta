import {DatePipe} from '@angular/common';
import {Component, ElementRef, Input} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {TypeaheadMatch} from 'ngx-bootstrap/typeahead';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {RolesListResponse} from '../../../../core/interfaces/Security/Response/rolesListResponse';
import {UserResponse} from '../../../../core/interfaces/Security/Response/userResponse';
import {UserForCreationDto} from '../../../../core/interfaces/Security/userForCreationDto';
import {UsersService} from '../../services/users.service';

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

  minDate!: Date;
  maxDate!: Date;
  date!: Date;

  userForm: any;
  roles: any[] = [];
  selected?: string;
  rolesList: RolesListResponse[] = [];

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: UsersService,
    public el: ElementRef
  ) {
  }

  changeTime(event: any) {
    const datePipe = new DatePipe('en-US');
    this.userForm.patchValue({
      birthDate: datePipe.transform(event, 'yyyy-MM-dd')
    })
  }

  onSelect(event: TypeaheadMatch): void {
    this.roles.push({
      roleId: event.item.id,
      name: event.item.name
    });
    this.selected = '';
  }

  ngOnInit(): void {
    this.minDate = new Date();
    this.maxDate = new Date();
    this.minDate.setDate(this.minDate.getDate() - 47450)

    this.userForm = new FormGroup({
      userName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl(''),
      birthDate: new FormControl(''),
      date: new FormControl(''),
      userRoles: new FormControl(''),
      promotionalMails: new FormControl(false),
    });
    if (!this.update && !this.read) {
      this.RetrieveNavigation();
    } else if (this.update) {
      this.service.GetManagement(this.id).subscribe((response: UserResponse) => {
        this.userForm.patchValue({
          userName: response.userName,
          email: response.email,
          birthDate: response.birthDate,
          promotionalMails: response.promotionalMails,
        });

        // let splitName = response.fullName.split(' ');

        // let firstName = splitName.slice(0, (splitName.length / 2)).join(' ');
        // let lastName = splitName.slice((splitName.length / 2)).join(' ');
        // this.userForm.patchValue({
        //   name: firstName,
        //   lastName: lastName
        // });


        this.roles = response.userRoles.map(userRole => userRole.role) || [];
      });
      this.RetrieveNavigation();
    } else if (this.read) {
      this.userForm = new FormGroup({
        userName: new FormControl(''),
        email: new FormControl(''),
        password: new FormControl(''),
        confirmPassword: new FormControl(''),
        birthDate: new FormControl(''),
        date: new FormControl(''),
        userRoles: new FormControl(''),
        promotionalMails: new FormControl(false),
        createdAt: new FormControl(''),
        createdBy: new FormControl(''),
        updatedAt: new FormControl(''),
        updatedBy: new FormControl(''),
      })

      this.service.GetManagement(this.id).subscribe((response: UserResponse) => {

        this.userForm.patchValue({
          userName: response.userName,
          email: response.email,
          birthDate: response.birthDate,
          promotionalMails: response.promotionalMails,
          createdAt: response.createdAt,
          createdBy: response.createdBy,
          updatedAt: response.updatedAt,
          updatedBy: response.updatedBy,
        });

        console.log(response)

        this.roles = response.userRoles.map(userRole => userRole.role) || [];
      });
    }
  }

  RetrieveNavigation() {
    this.service.GetRolesList().subscribe({
      next: (response: RolesListResponse[]) => {
        this.rolesList = response;
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  validate = (controlName: string, errorName: string) => {
    const control = this.userForm.get(controlName);
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
        const UserForUpdateDto: UserForCreationDto = {
          userName: user.userName,
          email: user.email,
          password: user.password,
          confirmPassword: user.confirmPassword,
          birthDate: this.date.toISOString(),
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
        const UserForCreationDto: UserForCreationDto = {
          userName: user.userName,
          email: user.email,
          password: user.password,
          confirmPassword: user.confirmPassword,
          birthDate: user.birthDate,
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
            console.log(error);
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

}
