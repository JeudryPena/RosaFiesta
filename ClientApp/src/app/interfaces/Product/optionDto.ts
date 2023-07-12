export interface OptionDto {
	title: string;
	description: string | null;
	price: number;
	quantityAvailable: number;
	color: string | null;
	isMale: boolean | null;
	condition: number;
	images: MultipleImageDto[] | null;
}