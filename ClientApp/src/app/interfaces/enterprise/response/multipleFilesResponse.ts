import { FileResponse } from "./fileResponse";

export interface MultipleFilesResponse {
    files: FileResponse[];
    isSuccesful: boolean;
    message: string;
    totalFiles: number;
}