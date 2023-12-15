import {DatePipe} from "@angular/common";
import {HttpResponse} from '@angular/common/http';
import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {TypeaheadMatch} from 'ngx-bootstrap/typeahead';
import {BehaviorSubject, lastValueFrom} from 'rxjs';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {CategoriesListResponse} from '../../../../core/interfaces/Product/Response/categoriesListResponse';
import {ProductResponse} from '../../../../core/interfaces/Product/Response/productResponse';
import {SuppliersListResponse} from '../../../../core/interfaces/Product/Response/suppliersListResponse';
import {WarrantiesListResponse} from '../../../../core/interfaces/Product/Response/warrantiesListResponse';
import {OptionDto} from '../../../../core/interfaces/Product/optionDto';
import {ProductDto} from '../../../../core/interfaces/Product/productDto';
import {CategoriesService} from '../../services/categories.service';
import {FilesService} from '@core/shared/services/files.service';
import {ProductsService} from '../../services/products.service';
import {SuppliersService} from '../../services/suppliers.service';
import {WarrantiesService} from '../../services/warranties.service';

@Component({
  selector: 'app-modal-product',
  templateUrl: './modal-product.component.html',
  styleUrls: ['./modal-product.component.scss']
})
export class ModalProductComponent implements OnInit {
  updateOption = false;
  optionTitle = '';

  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() productId: string = '';

  productForm$: BehaviorSubject<FormGroup<any>> = new BehaviorSubject<FormGroup<any>>(null);
  options: any[] = [];
  optionForm: any;
  optionFirst!: number;
  imageFirst!: number | null;

  categoryForm!: CategoriesListResponse;
  warrantyForm!: WarrantiesListResponse | null;
  supplierForm!: SuppliersListResponse | null;
  categorySelected: string | undefined = undefined;
  warrantySelected: string | null = null;
  supplierSelected: string | null = null;
  categories: CategoriesListResponse[] = [];
  warranties: WarrantiesListResponse[] = [];
  suppliers: SuppliersListResponse[] = [];
  uploadFiles: File[] = [];
  pictures: any[] = [];

  constructor(
    private modalService: NgbModal,
    public activeModal: NgbActiveModal,
    private service: ProductsService,
    private categoriesService: CategoriesService,
    private warrantiesService: WarrantiesService,
    private suppliersService: SuppliersService,
    private filesService: FilesService,
    private fb: FormBuilder,
    private datePipe: DatePipe
  ) {

  }

  async ngOnInit() {
    if (!this.update && !this.read)
      this.onCreate();
    else if (this.update) {
      this.onEdit();
    } else if (this.read) {
      this.onRead();
    }
  }

  async onCreate() {
    await this.RetrieveRelations();
    this.productForm$.next(this.fb.group({
      code: [''],
      options: [],
      isService: [false],
      categoryId: [''],
      warrantyId: [''],
      supplierId: ['']
    }));
  }

  async onEdit() {
    const product$ = this.service.GetProduct(this.productId);
    let response: ProductResponse = await lastValueFrom(product$);
    this.optionFirst = response.options.indexOf(response.option)
    this.categoryForm = response.category;
    this.warrantyForm = response.warranty;
    this.supplierForm = response.supplier;
    this.options = response.options || [];
    this.ReSelect()
    await this.RetrieveRelations();
    this.productForm$.next(this.fb.group({
      code: [response.code],
      isService: [response.isService],
    }));
  }

  async onRead() {
    const product$ = this.service.GetProduct(this.productId);
    let response: ProductResponse = await lastValueFrom(product$);
    this.optionFirst = this.optionFirst = response.options.indexOf(response.option)
    this.categoryForm = response.category;
    this.warrantyForm = response.warranty;
    this.supplierForm = response.supplier;
    this.options = response.options || [];
    this.ReSelect()
    this.productForm$.next(this.fb.group({
      code: [response.code],
      isService: [response.isService],
      option: [response.option],
      createdAt: [this.datePipe.transform(response.createdAt, 'dd-MMM-yyyy h:mm:ss a')],
      updatedAt: [this.datePipe.transform(response.updatedAt, 'dd-MMM-yyyy h:mm:ss a')],
      createdBy: [response.createdBy],
      updatedBy: [response.updatedBy],
    }));
  }

  onSelect(event: TypeaheadMatch, form: string): void {
    if (form == 'category') {
      this.categoryForm = event.item;
    } else if (form == 'warranty') {
      this.warrantyForm = event.item;
    } else if (form == 'supplier') {
      this.supplierForm = event.item;
    }
  }

  SelectFirst(index: number) {
    this.optionFirst = index;
  }

  async ReadImages(images: any) {
    for (const image of images) {
      let i = image.image;
      const file$ = this.filesService.getPhoto(i);
      let response: any = await lastValueFrom(file$);
      const fileName = i.split('\\').pop();
      this.RetrieveFile(response, fileName);
    }
    this.preview();
  }

  RetrieveFile(data: HttpResponse<Blob>, fileName: string) {
    if (data.body) {

      const downloadedFile = new Blob([data.body], {type: data.body.type});

      const file = new File([downloadedFile], fileName, {type: `${data.body.type}`});

      this.uploadFiles.push(file);
    }
  }

  ReSelect() {
    this.categorySelected = this.categoryForm?.name;
    this.warrantySelected = this.warrantyForm?.name ? this.warrantyForm.name : null;
    this.supplierSelected = this.supplierForm?.name ? this.supplierForm.name : null;
  }

  async RetrieveRelations() {
    this.categoriesService.GetCategoriesList().subscribe({
      next: (response) => {
        this.categories = response;
      }, error: (error) => {
        console.log(error);
      }
    });
    this.warrantiesService.GetWarrantiesList().subscribe({
      next: (response) => {
        this.warranties = response;
      }, error: (error) => {
        console.log(error);
      }
    });

    this.suppliersService.GetList().subscribe({
      next: (response) => {
        this.suppliers = response;
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  addNewOption(name: string) {
    this.optionTitle = 'Añadir Opción'

    this.optionForm = new FormGroup({
      id: new FormControl(''),
      title: new FormControl(name),
      description: new FormControl(''),
      price: new FormControl(0),
      color: new FormControl(''),
      genderFor: new FormControl(0),
      condition: new FormControl(0),
      images: new FormControl(''),
      quantityAvailable: new FormControl(0),
    })
  }

  saveOption(optionFormValue: any) {
    const option = {...optionFormValue};
    option.images = this.uploadFiles;
    const optionDto: OptionDto = {
      id: option.id,
      title: option.title,
      description: option.description,
      price: option.price,
      color: option.color,
      genderFor: option.genderFor,
      condition: option.condition,
      images: option.images,
      imageIndex: this.imageFirst,
      quantityAvailable: option.quantityAvailable
    }
    this.imageFirst = null;
    if (this.options.length == 0) {
      this.optionFirst = 0;
    }
    this.options.push(optionDto);
    this.uploadFiles = [];
    this.pictures = [];
    this.optionForm = null;
  }

  updateOpt(optionFormValue: any) {
    const option = {...optionFormValue};
    option.images = this.uploadFiles;
    const optionDto: OptionDto = {
      id: option.id,
      title: option.title,
      description: option.description,
      price: option.price,
      color: option.color,
      genderFor: option.genderFor,
      condition: option.condition,
      images: option.images,
      imageIndex: this.imageFirst,
      quantityAvailable: option.quantityAvailable
    }
    this.uploadFiles = [];
    this.pictures = [];
    this.imageFirst = null;
    this.options[option.index] = optionDto;
    this.updateOption = false;
    this.optionForm = null;
  }

  selectOption(index: number) {
    this.updateOption = true;
    this.optionTitle = 'Modificar Opción'
    this.optionForm = new FormGroup({
      index: new FormControl(index),
      id: new FormControl(this.options[index].id),
      title: new FormControl(this.options[index].title),
      description: new FormControl(this.options[index].description),
      price: new FormControl(this.options[index].price),
      color: new FormControl(this.options[index].color),
      genderFor: new FormControl(this.options[index].genderFor),
      condition: new FormControl(this.options[index].condition),
      images: new FormControl(this.options[index].images),
      imageId: new FormControl(this.options[index].imageId),
      quantityAvailable: new FormControl(this.options[index].quantityAvailable),
    })
    this.imageFirst = this.options[index].imageIndex;
    if (this.update == true || this.read == true) {
      this.ReadImages(this.options[index].images);
    } else {
      this.uploadFiles = this.options[index].images;
    }
    setTimeout(() => {

    }, 10);
  }

  preview() {
    console.log(this.uploadFiles);
    this.uploadFiles.forEach(f => {
      console.log(f);
      const reader = new FileReader();
      reader.readAsDataURL(f);
      reader.onload = () => {
        this.pictures.push(reader.result);
      };
    });
  }

  validate = (controlName: string, errorName: string) => {
    const form = this.productForm$.getValue();
    const control = form.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  validateOption = (controlName: string, errorName: string) => {
    const control = this.optionForm.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  cancelOption() {
    this.updateOption = false;
    this.uploadFiles = [];
    this.pictures = [];
    this.optionForm = null;
    this.imageFirst = null;
  }

  removeOption(index: number) {
    this.options.splice(index, 1);
  }

  close() {
    this.activeModal.close();
  }

  async updateProduct(productFormValue: any) {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea actualizar el Producto?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const product = {...productFormValue};
        if (this.options.length !== 0)
          this.UpdateImages();
        else
          this.OnUpdateProduct(product);
      }
    });
  }

  async UpdateImages() {
    for (const option of this.options) {
      const files = option.images.filter((image: any) => image instanceof File);
      if (files != null && files.length > 0) {
        option.images = await this.filesService.UpdateFiles(option.images, option.id);
      }
    }
  }

  OnUpdateProduct(product: any) {
    const productDto: ProductDto = {
      code: product.code,
      isService: product.isService,
      optionIndex: this.optionFirst,
      categoryId: this.categoryForm.id,
      warrantyId: this.warrantyForm?.id || null,
      supplierId: this.supplierForm?.id || null,
      options: this.options
    }
    this.service.UpdateProduct(this.productId, productDto).subscribe({
      next: () => {
        const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
        modalRef.componentInstance.title = 'Producto actualizado!';
        modalRef.componentInstance.status = Status.Success;
        modalRef.result.then(result => {
          this.activeModal.close(true);
        });
      }, error: (error) => {
        const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
        modalRef.componentInstance.title = error;
        modalRef.componentInstance.status = Status.Failed;
      }
    });
  }

  async AddProduct(productFormValue: any) {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea guardar el Producto?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(async result => {
      if (result) {
        const product = {...productFormValue};
        if (this.options.length !== 0) {
          await this.AddImages();
        }
        await this.OnAddProduct(product);
      }
    });
  }

  async AddImages() {
    for (const option of this.options) {
      const files = option.images.filter((image: any) => image instanceof File);
      if (files != null && files.length > 0) {
        option.images = await this.filesService.UploadFiles(option.images);
      }
    }
  }

  async OnAddProduct(product: any) {
    const productDto: ProductDto = {
      code: product.code ? product.code : null,
      isService: product.isService,
      optionIndex: this.optionFirst,
      categoryId: this.categoryForm.id,
      warrantyId: this.warrantyForm?.id || null,
      supplierId: this.supplierForm?.id || null,
      options: this.options,
    }
    this.service.AddProduct(productDto).subscribe({
      next: () => {
        const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
        modalRef.componentInstance.title = 'Producto guardado!';
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
}