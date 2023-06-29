import { OptionDto } from "./optionDto";

export interface ProductUpdateDto {
    code: string | null;
    title: string | null;
    brand: string | null;
    warrantyId: string | null;
    option: OptionDto | null;
}