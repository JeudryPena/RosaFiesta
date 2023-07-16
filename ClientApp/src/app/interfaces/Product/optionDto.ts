import { MultipleImageDto } from "./UserInteract/multipleImageDto";

export interface OptionDto {
	id: string;
	title: string;
	description: string | null;
	price: number;
	quantityAvailable: number;
	color: string | null;
	genderFor: number;
	condition: number;
	images: MultipleImageDto[] | null;
	imageId: number | null;
}