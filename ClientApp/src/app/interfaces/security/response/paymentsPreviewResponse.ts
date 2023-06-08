export interface PaymentsPreviewResponse {
	id: string;
	name: string;
	description: string;
	payMethodType: string;
	createdAt: string;
	isDefault: boolean | null;
}