import { MultipleImagesResponse } from "./multipleImagesResponse";

export interface OptionResponse {
    id: string;
    title: string;
    description: string | null;
    price: number;
    genderFor: string;
    image: string | null;
    stock: string;
    quantityAvailable: number;
    images: MultipleImagesResponse[];
    condition: string;
}