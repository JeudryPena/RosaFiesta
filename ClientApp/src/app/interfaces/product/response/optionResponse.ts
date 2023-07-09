import { MultipleImagesResponse } from "./multipleImagesResponse";

export interface OptionResponse {
	id: number;
	title: string;
	description: string | null;
	price: number;
	color: string | null;
	size: number | null;
	weight: number;
	genderFor: string | null;
	material: string | null;
	condition: string;
	images: MultipleImagesResponse[];
	stock: string;
	quantityAvailable: number;
}