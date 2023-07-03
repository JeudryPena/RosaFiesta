import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { CategoriesListResponse } from '../../interfaces/Product/Response/categories-list-response';
import { ProductResponse } from '../../interfaces/Product/Response/productResponse';
import { SubCategoriesListResponse } from '../../interfaces/Product/Response/sub-categories-list-response';
import { SuppliersListResponse } from '../../interfaces/Product/Response/suppliers-list-response';
import { WarrantiesListResponse } from '../../interfaces/Product/Response/warranties-list-response';
import { MultipleImageDto } from '../../interfaces/Product/UserInteract/multipleImageDto';
import { OptionDto } from '../../interfaces/Product/optionDto';
import { ProductDto } from '../../interfaces/Product/productDto';
import { CategoriesService } from '../../shared/services/categories.service';
import { ProductsService } from '../../shared/services/products.service';
import { SuppliersService } from '../../shared/services/suppliers.service';
import { WarrantiesService } from '../../shared/services/warranties.service';
import { FilesService } from '../../shared/services/files.service';

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

  codeFocused = false;
  nameFocused = false;
  brandFocused = false;
  typeFocused = false;
  optionsFocused = false;
  categoryIdFocused = false;
  subCategoryIdFocused = false;
  warrantyIdFocused = false;
  supplierIdFocused = false;

  titleFocused = false;
  descriptionFocused = false;
  priceFocused = false;
  quantityAvailableFocused = false;
  colorFocused = false;
  sizeFocused = false;
  weightFocused = false;
  genderForFocused = false;
  materialFocused = false;
  conditionFocused = false;
  imagesFocused = false;

  productForm: any;
  options: any[] = [];
  optionForm: any;
  categoryForm!: CategoriesListResponse;
  subCategoryForm: SubCategoriesListResponse = {
    id: 0,
    name: ''
  }
  warrantyForm: WarrantiesListResponse = {
    id: '',
    name: ''
  }
  supplierForm: SuppliersListResponse = {
    id: '',
    name: ''
  }
  categorySelected?: string;
  subCategorySelected!: string;
  warrantySelected!: string;
  supplierSelected!: string;
  categories: CategoriesListResponse[] = [];
  subCategories: SubCategoriesListResponse[] = [];
  warranties: WarrantiesListResponse[] = [];
  suppliers: SuppliersListResponse[] = [];
  responseImgs: MultipleImageDto[] = [];
  uploadFiles: any[] = [];

  constructor(
    private modalService: NgbModal,
    public activeModal: NgbActiveModal,
    private service: ProductsService,
    private categoriesService: CategoriesService,
    private warrantiesService: WarrantiesService,
    private suppliersService: SuppliersService,
    private filesService: FilesService
  ) {
    
  }

  onSelect(event: TypeaheadMatch, form: string): void {
    if (form == 'category') {
      this.categoryForm = event.item;
      this.categoriesService.GetSubCategoriesList(this.categoryForm.id).subscribe((response: SubCategoriesListResponse[]) => {
        this.subCategories = response;
      });
    }
    else if (form == 'subCategory') {
      this.subCategoryForm = event.item;
    }
    else if (form == 'warranty') {
      this.warrantyForm = event.item;
    }
    else if (form == 'supplier') {
      this.supplierForm = event.item;
    }
  }

  ngOnInit(): void {
    this.productForm = new FormGroup({
      code: new FormControl(''),
      name: new FormControl(''),
      brand: new FormControl(''),
      options: new FormControl(''),
      categoryId: new FormControl(null),
      subCategoryId: new FormControl(null),
      warrantyId: new FormControl(''),
      supplierId: new FormControl(''),
    })
    if (this.update) {
      this.service.GetProduct(this.productId).subscribe((response: ProductResponse) => {
        this.productForm.patchValue({
          code: response.code,
          name: response.name,
          brand: response.brand,
          categoryId: response.categoryId,
          subCategoryId: response.subCategoryId,
          warrantyId: response.warrantyId,
          supplierId: response.supplierId,
        });
        this.options = response.options || [];
      });
    } else if (this.read) {
      this.productForm = new FormGroup({
        code: new FormControl(''),
        name: new FormControl(''),
        brand: new FormControl(''),
        options: new FormControl(''),
        categoryId: new FormControl(null),
        subCategoryId: new FormControl(null),
        warrantyId: new FormControl(''),
        supplierId: new FormControl(''),
        createdAt: new FormControl(''),
        updatedAt: new FormControl(''),
        createdBy: new FormControl(''),
        updatedBy: new FormControl(''),
      })

      this.service.GetProduct(this.productId).subscribe((response: ProductResponse) => {
        this.productForm.patchValue({
          code: response.code,
          name: response.name,
          brand: response.brand,
          categoryId: response.categoryId,
          subCategoryId: response.subCategoryId,
          warrantyId: response.warrantyId,
          supplierId: response.supplierId,
          createdAt: response.createdAt,
          updatedAt: response.updatedAt,
          createdBy: response.createdBy,
          updatedBy: response.updatedBy,
        });
        this.options = response.options || [];
      });
    }
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

  uploadImagesFinished = (event: any) => {
    console.log(event);
    this.responseImgs.push({
      image: event
    });
    console.log(this.responseImgs);
  }

  addNewOption(name: string) {
    this.optionTitle = 'Añadir Opción'
    this.optionForm = new FormGroup({
      title: new FormControl(name),
      description: new FormControl(''),
      price: new FormControl(0),
      color: new FormControl(''),
      size: new FormControl(0),
      weight: new FormControl(0),
      genderFor: new FormControl(0),
      material: new FormControl(0),
      condition: new FormControl(0),
      images: new FormControl(''),
      quantityAvailable: new FormControl(0),
    })
    setTimeout(() => {

    }, 10);
  }

  saveOption(optionFormValue: any) {
    const option = { ...optionFormValue };
    option.images = this.uploadFiles;
    const optionDto: OptionDto = {
      title: option.title,
      description: option.description,
      price: option.price,
      color: option.color,
      size: option.size,
      weight: option.weight,
      genderFor: option.genderFor,
      material: option.material,
      condition: option.condition,
      images: option.images,
      quantityAvailable: option.quantityAvailable
    }
    this.options.push(optionDto);
    this.uploadFiles = [];
    this.optionForm = null;
  }

  updateOpt(optionFormValue: any) {
    const option = { ...optionFormValue };
    option.images = this.uploadFiles;
    const optionDto: OptionDto = {
      title: option.title,
      description: option.description,
      price: option.price,
      color: option.color,
      size: option.size,
      weight: option.weight,
      genderFor: option.genderFor,
      material: option.material,
      condition: option.condition,
      images: option.images,
      quantityAvailable: option.quantityAvailable
    }
    this.uploadFiles = [];
    this.options[option.index] = optionDto;
    this.updateOption = false;
    this.optionForm = null;
  }

  selectOption(index: number) {
    this.updateOption = true;
    this.optionTitle = 'Modificar Opción'
    this.optionForm = new FormGroup({
      title: new FormControl(this.options[index].title),
      description: new FormControl(this.options[index].description),
      price: new FormControl(this.options[index].price),
      color: new FormControl(this.options[index].color),
      size: new FormControl(this.options[index].size),
      weight: new FormControl(this.options[index].weight),
      genderFor: new FormControl(this.options[index].genderFor),
      material: new FormControl(this.options[index].material),
      condition: new FormControl(this.options[index].condition),
      images: new FormControl(this.options[index].images),
      quantityAvailable: new FormControl(this.options[index].quantityAvailable),
    })
    this.uploadFiles = this.options[index].images; 
    setTimeout(() => {

    }, 10);
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.productForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  validateOption = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.optionForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  cancelOption() {
    this.updateOption = false;
    this.optionForm = null;
  }

  removeOption(index: number) {
    this.options.splice(index, 1);
  }

  close() {
    this.activeModal.close();
  }

  updateProduct = (productFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea actualizar el Producto?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const product = { ...productFormValue };

        const productDto: ProductDto = {
          code: product.code,
          name: product.name,
          brand: product.brand,
          categoryId: product.categoryId,
          subCategoryId: product.subCategoryId,
          warrantyId: product.warrantyId,
          supplierId: product.supplierId,
          options: this.options,
        }
        this.service.UpdateProduct(this.productId, productDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Producto actualizado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
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

  AddProduct = (productFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea guardar el Producto?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const product = { ...productFormValue };
        this.options.forEach(option => {
          const images = this.filesService.UploadFiles(option.images);
          option.images.push({ ...option, images: images });
          console.log(this.options);
          console.log(images);
        });
        const productDto: ProductDto = {
          code: product.code,
          name: product.name,
          brand: product.brand,
          categoryId: this.categoryForm.id,
          subCategoryId: this.subCategoryForm.id || null,
          warrantyId: this.warrantyForm.id || null,
          supplierId: this.supplierForm.id || null,
          options: this.options,
        }
        console.log(productDto);
        this.service.AddProduct(productDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Producto guardado!';
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
