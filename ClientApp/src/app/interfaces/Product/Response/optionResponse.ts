import { MultipleImagesResponse } from "./multipleImagesResponse";

export interface OptionResponse {
    id: string;
    title: string;
    description: string | null;
    price: number;
    image: string | null;
    stock: string;
    quantityAvailable: number;
    images: MultipleImagesResponse[];
    condition: string;
}