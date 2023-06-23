import { BaseResponse } from '../../base-response';
import { SubCategoryManagementResponse } from './subCategoryManagementResponse';

export interface CategoryManagementResponse extends BaseResponse {
	id: number;
	name: string;
	icon: string;
	description: string | null;
	subCategories: SubCategoryManagementResponse[] | null;
	expanded?: boolean;
	createdBy: string;
	updatedBy: string;
}