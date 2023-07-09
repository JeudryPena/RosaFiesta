using Contracts.Model.Product.UserInteract;

using Microsoft.AspNetCore.Http;

namespace Services.Abstractions;

public interface IFileService
{
	Task<MultipleImageDto> FileManage(IFormFile file, string folder);
	Task<IList<MultipleImageDto>> MultipleFilesManage(IFormFileCollection files, string folder);
}