import { ByBaseResponse } from '../../by-base-response';
import { SubCategoryManagementResponse } from './subCategoryManagementResponse';

export interface CategoryManagementResponse extends ByBaseResponse {
	id: number;
	name: string;
	icon: string;
	description: string | null;
	subCategories: SubCategoryManagementResponse[] | null;
	expanded?: boolean;
}