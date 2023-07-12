import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductPreviewResponse {
    id: string;
    options: OptionPreviewResponse;
}