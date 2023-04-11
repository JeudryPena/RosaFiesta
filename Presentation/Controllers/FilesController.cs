using Contracts.Model.Enterprise.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FilesController : ControllerBase
{
    private readonly IFileService _fileService;
    private const string pdfFolder = "Documents";
    private const string imageFolder = "Images";

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("pdf")]
    public async Task<ActionResult<FileResponse>> UploadPdfs()
    {
        try
        {
            var formCollection = await Request.ReadFormAsync();
            
            var file = formCollection.Files[0];
            var response = await _fileService.FileManage(file, pdfFolder);
            if(!response.isSuccesful){
                ModelState.AddModelError("File", response.Message);
                return BadRequest(ModelState);
            }
            var dbPath = Path.Combine(response.FileLocation, response.FileName);
            return Ok(new { dbPath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }
    
    [HttpPost("image")]
    public async Task<ActionResult<FileResponse>> UploadImages()
    {
        try
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files[0];
            var response = await _fileService.FileManage(file, imageFolder);
            if(!response.isSuccesful){
                ModelState.AddModelError("File", response.Message);
                return BadRequest(ModelState);
            }
            var dbPath = Path.Combine(response.FileLocation, response.FileName);
            return Ok(new { dbPath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }
    
    [HttpPost ("multiPdfs")]
    public async Task<ActionResult<MultipleFilesResponse>> UploadMultiplePdfs()
    {
        try
        {
            var files = Request.Form.Files;
            var response = await _fileService.MultipleFilesManage(files, pdfFolder);
            if(!response.isSuccesful){
                ModelState.AddModelError("File", response.Message);
                return BadRequest(ModelState);
            }
            return Ok(new { response.Files});
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    
    [HttpPost ("multiImages")]
    public async Task<ActionResult<MultipleFilesResponse>> UploadMultipleImages()
    {
        try
        {
            var files = Request.Form.Files;
            var response = await _fileService.MultipleFilesManage(files, imageFolder);
            if(!response.isSuccesful){
                ModelState.AddModelError("File", response.Message);
                return BadRequest(ModelState);
            }
            return Ok(new { response.Files});
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}