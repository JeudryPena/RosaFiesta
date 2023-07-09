using Contracts.Model.Product.UserInteract;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

using Services.Abstractions;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FilesController : ControllerBase
{
	private readonly IServiceManager _serviceManager;
	private const string pdfFolder = "Documents";
	private const string imageFolder = "Images";

	public FilesController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpPost("pdf")]
	public async Task<IActionResult> UploadPdfs()
	{
		var formCollection = await Request.ReadFormAsync();

		var file = formCollection.Files[0];
		var response = await _serviceManager.FileService.FileManage(file, pdfFolder);
		return Ok(response);
	}

	[HttpPost("image")]
	public async Task<IActionResult> UploadImages()
	{
		var formCollection = await Request.ReadFormAsync();
		var file = formCollection.Files[0];
		var response = await _serviceManager.FileService.FileManage(file, imageFolder);
		return Ok(response);
	}

	[HttpPost("multiPdfs")]
	public async Task<ActionResult<IList<string>>> UploadMultiplePdfs()
	{
		var files = Request.Form.Files;
		var response = await _serviceManager.FileService.MultipleFilesManage(files, pdfFolder);
		return Ok(response);
	}

	[HttpPost("multiImages")]
	public async Task<IActionResult> UploadMultipleImages()
	{
		var formCollection = await Request.ReadFormAsync();
		var files = formCollection.Files;
		IList<MultipleImageDto> response = await _serviceManager.FileService.MultipleFilesManage(files, imageFolder);
		return Ok(response);
	}

	[HttpGet("getPhotos"), DisableRequestSizeLimit]
	public IActionResult GetPhotos(List<string> paths)
	{
		var results = new List<byte[]>();
		foreach (var path in paths)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
			if (!System.IO.File.Exists(filePath))
				return NotFound();

			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				byte[] fileData = new byte[stream.Length];
				stream.Read(fileData, 0, fileData.Length);
				results.Add(fileData);
			}
		}
		return Ok(results);
	}

	[HttpGet("getAllPhotos"), DisableRequestSizeLimit]
	public IActionResult GetAllPhotos()
	{
		var folderName = Path.Combine("Resources", "Images");
		var pathToRead = Path.Combine(Directory.GetCurrentDirectory(), folderName);
		var photos = Directory.EnumerateFiles(pathToRead)
			.Where(IsAPhotoFile)
			.Select(fullPath => Path.Combine(folderName, Path.GetFileName(fullPath)));
		return Ok(new { photos });
	}
	private bool IsAPhotoFile(string fileName)
	{
		return fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
			|| fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
			|| fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
	}

	[HttpGet("getPhoto"), DisableRequestSizeLimit]
	public async Task<IActionResult> GetPhoto([FromQuery] string fileUrl)
	{
		var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileUrl);
		if (!System.IO.File.Exists(filePath))
			return NotFound();
		var memory = new MemoryStream();
		await using (var stream = new FileStream(filePath, FileMode.Open))
		{
			await stream.CopyToAsync(memory);
		}
		memory.Position = 0;
		return File(memory, GetContentType(filePath), filePath);
	}

	private string GetContentType(string path)
	{
		var provider = new FileExtensionContentTypeProvider();
		string contentType;

		if (!provider.TryGetContentType(path, out contentType))
		{
			contentType = "application/octet-stream";
		}

		return contentType;
	}

	[HttpDelete("delete"), DisableRequestSizeLimit]
	public async Task<IActionResult> Delete([FromQuery] string fileUrl)
	{
		var message = "Delete end-point hit!";
		var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileUrl);

		if (!System.IO.File.Exists(filePath))
			return NotFound();

		System.IO.File.Delete(filePath);
		return Ok(new { message });
	}

	[HttpPut("updateFiles/options/{optionId}")]
	public async Task<IActionResult> UpdateFiles(int optionId, CancellationToken token)
	{
		var formCollection = await Request.ReadFormAsync();
		var files = formCollection.Files;

		var existingFiles = await GetExistingFilesForProduct(optionId, token);

		IList<MultipleImageDto> result = new List<MultipleImageDto>();
		var imagesPath = Path.Combine("Resources", imageFolder);

		foreach (var existingFile in existingFiles)
		{
			if (!files.Any(f => Path.Combine(imagesPath, f.FileName) == existingFile))
			{
				DeleteFile(existingFile);
			}
			else
				result.Add(new MultipleImageDto { Image = existingFile });
		}

		foreach (var newFile in files)
		{
			if (!existingFiles.Any(f => f == Path.Combine(imagesPath, newFile.FileName)))
			{
				MultipleImageDto response = await _serviceManager.FileService.FileManage(newFile, imageFolder);
				result.Add(response);
			}
		}
		return Ok(result);
	}

	private void DeleteFile(string fileName)
	{
		var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
		System.IO.File.Delete(filePath);
	}

	private async Task<IList<string>> GetExistingFilesForProduct(int optionId, CancellationToken cancellationToken)
	{
		var response = await _serviceManager.ProductService.GetOptionImages(optionId, cancellationToken);
		return response;
	}
}