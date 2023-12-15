import {Component, QueryList, ViewChildren} from '@angular/core';
import {NgbModal, NgbModalConfig} from '@ng-bootstrap/ng-bootstrap';
import {Observable} from 'rxjs';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {ManagementUsersResponse} from '../../../../core/interfaces/Security/Response/managementUsersResponse';
import {NgbdSortableHeader, SortEvent} from '@core/shared/directives/sortable.directive';
import {UsersService} from '../../services/users.service';
import {ModalUserComponent} from '../../components/modal-user/modal-user.component';

@Component({
  selector: 'app-management-users',
  templateUrl: './management-users.component.html',
  styleUrls: ['./management-users.component.scss']
})
export class ManagementUsersComponent {
  users$: Observable<ManagementUsersResponse[]> = new Observable<ManagementUsersResponse[]>();
  total$: Observable<number> = new Observable<number>();
  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: UsersService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.retrieveData();
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  retrieveData() {
    this.service.RetrieveData();
    this.users$ = this.service.users$;
    this.total$ = this.service.total$;
  }

  Retrieve(id: string) {
    const modalRef = this.modalService.open(ModalUserComponent, {size: 'lg', scrollable: true});
    modalRef.componentInstance.title = 'Consultar usuario';
    modalRef.componentInstance.id = id;
    modalRef.componentInstance.read = true;
  }

  Modify(id: string) {
    const modalRef = this.modalService.open(ModalUserComponent, {size: 'lg', scrollable: true});
    modalRef.componentInstance.title = 'Modificar usuario';
    modalRef.componentInstance.update = true;
    modalRef.componentInstance.id = id;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  Delete(id: string) {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea eliminar el usuario?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.Delete(id).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Usuario eliminado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.retrieveData()
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

  DeleteRoles(id: string, roleId: string) {
    console.log(id, roleId)
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea eliminar el rol del usuario?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteRoles(id, roleId).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Rol del usuario eliminado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.retrieveData()
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

  Add() {
    const modalRef = this.modalService.open(ModalUserComponent, {size: 'lg', scrollable: true});
    modalRef.componentInstance.title = 'Añadir usuario';
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  onSort({column, direction}: SortEvent) {
    this.headers.forEach((header) => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }
}
