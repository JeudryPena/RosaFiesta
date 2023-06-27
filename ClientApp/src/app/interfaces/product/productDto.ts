import { CategoryDto } from "./categoryDto";
import { OptionDto } from "./optionDto";

export interface ProductDto {
    code: string | null;
    title: string;
    options: OptionDto[];
    type: number;
    categoryId: number | null;
    category: CategoryDto | null;
    warrantyId: string | null;
    supplierId: string | null;
}