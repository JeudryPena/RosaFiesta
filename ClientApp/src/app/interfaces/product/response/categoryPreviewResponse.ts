import { SubCategoryPreviewResponse } from './subCategoryPreviewResponse';

export interface CategoryPreviewResponse {
	id: number;
	name: string;
	icon: string;
	description: string | null;
	subCategories: SubCategoryPreviewResponse[] | null;
	expanded?: boolean;
	
}