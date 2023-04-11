using Contracts.Model.Enterprise.Response;
using Microsoft.AspNetCore.Http;

namespace Services.Abstractions;

public interface IFileService
{
    Task<FileResponse> FileManage(IFormFile file, string folder);
    Task<MultipleFilesResponse> MultipleFilesManage(IFormFileCollection files, string folder);
    string GenerateCircle(string candidateName);
}