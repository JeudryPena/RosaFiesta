using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
		IList<string> response = await _serviceManager.FileService.MultipleFilesManage(files, imageFolder);
		return Ok(response);
	}
}