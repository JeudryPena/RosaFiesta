import { OptionDto } from "./optionDto";

export interface ProductDto {
    code: string | null;
    name: string;
    brand: string | null;
    options: OptionDto[];
    categoryId: number;
    subCategoryId: number | null;
    warrantyId: string | null;
    supplierId: string | null;
}