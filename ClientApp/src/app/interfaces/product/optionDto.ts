import { MultipleImageDto } from "./UserInteract/multipleImageDto";

export interface OptionDto {
    id: number | null;
    title: string;
    description: string | null;
    price: number;
    quantityAvailable: number;
    color: string | null;
    size: number | null;
    weight: number;
    genderFor: number | null;
    material: number | null;
    condition: number;
    images: MultipleImageDto[] | null;
}