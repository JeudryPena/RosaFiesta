import { OptionDto } from "./optionDto";

export interface ProductDto {
	code: string | null;
	isService: boolean;
	options: OptionDto[];
	categoryId: number;
	warrantyId: string | null;
	supplierId: string | null;
	optionIndex: number;
}