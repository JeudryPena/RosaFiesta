import { MultipleImageDto } from "./UserInteract/multipleImageDto";

export interface OptionDto {
    description: string | null;
    price: number;
    quantity: number;
    brand: string | null;
    color: string | null;
    size: number | null;
    weight: number;
    genderFor: number | null;
    material: number | null;
    condition: number;
    images: MultipleImageDto[] | null;
    thumbnail: string | null;
    quantityAvaliable: number;
}