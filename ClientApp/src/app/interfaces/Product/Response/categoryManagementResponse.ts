import { BaseResponse } from '../../base-response';
import { SubCategoryPreviewResponse } from './subCategoryPreviewResponse';

export interface CategoryManagementResponse extends BaseResponse {
	id: number;
	name: string;
	icon: string;
	description: string | null;
	subCategories: SubCategoryPreviewResponse[] | null;
	expanded?: boolean;
	createdBy: string;
	updatedBy: string;
}