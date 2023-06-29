import { MultipleImageDto } from "./UserInteract/multipleImageDto";

export interface OptionUpdateDto {
    description: string | null;
    price: number | null;
    quantity: number | null;
    brand: string | null;
    color: string | null;
    size: number | null;
    weight: number;
    genderFor: number | null;
    material: number | null;
    condition: number | null;
    images: MultipleImageDto[] | null;
    quantityAvailable: number;
}