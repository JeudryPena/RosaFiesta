import { MultipleImagesResponse } from "./multipleImagesResponse";

export interface OptionsResponse {
    id: string;
    title: string;
    description: string | null;
    price: number;
    color: string | null;
    isMale: boolean | null;
    condition: number;
    stock: string;
    quantityAvailable: number;
    images: MultipleImagesResponse[];
}