import { MultipleImageDto } from "./UserInteract/multipleImageDto";

export interface OptionDto {
	id: string;
	title: string;
	description: string | null;
	price: number;
	quantityAvailable: number;
	color: string | null;
	isMale: boolean | null;
	condition: number;
	images: MultipleImageDto[] | null;
}