export interface OptionResponse {
	id: number;
	color: string | null;
	size: number | null;
	weight: number;
	genderFor: string | null;
	material: string | null;
	condition: string;
	description: string | null;
	price: number;
	images: string | null;
	stock: string;
	quantityAvaliable: number;
}