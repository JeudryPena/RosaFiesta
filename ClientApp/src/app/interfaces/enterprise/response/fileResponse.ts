export interface FileResponse {
    fileId: string;
    fileName: string;
    contentType: string;
    fileContent: string;
    fileExtension: string;
    fileLocation: string;
    fileUrl: string;
    fileSize: number;
    contentDisposition: string;
    fileDate: string;
    fileDescription: string;
    isSuccesful: boolean;
    message: string;
}