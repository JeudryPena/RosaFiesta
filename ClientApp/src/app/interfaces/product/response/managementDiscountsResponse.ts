export interface ManagementDiscountsResponse {
	code: string;
	name: string;
	type: string;
	value: number;
	maxTimesApply: number;
	start: string;
	end: string;
	description: string | null;
}