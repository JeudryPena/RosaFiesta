import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductPreviewResponse {
    id: string;
    isService: boolean;
    option: OptionPreviewResponse;
}