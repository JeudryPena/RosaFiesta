using Microsoft.AspNetCore.Http;

namespace Services.Abstractions;

public interface IFileService
{
	Task<string> FileManage(IFormFile file, string folder);
	Task<IList<string>> MultipleFilesManage(IFormFileCollection files, string folder);
}