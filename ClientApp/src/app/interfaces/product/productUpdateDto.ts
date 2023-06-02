import { OptionDto } from "./optionDto";

export interface ProductUpdateDto {
    code: string | null;
    title: string | null;
    brand: string | null;
    type: number | null;
    warrantyId: string | null;
    option: OptionDto | null;
}