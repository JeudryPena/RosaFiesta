import { FileResponse } from "./fileResponse";

export interface MultipleFilesResponse {
    image: string[];
    isSuccesful: boolean;
    message: string;
}