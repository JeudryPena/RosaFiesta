namespace Contracts.Model.Enterprise.Response;

public class FileResponse
{
	public string Image { get; set; }
	public string FileName { get; set; }
}

/*public class FileController : Controller
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly IConfiguration _configuration;

    public FileController(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
    {
        _hostingEnvironment = hostingEnvironment;
        _configuration = configuration;
    }

    [HttpPost("api/upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var fileName = Path.GetFileName(file.FileName);
        var fileExt = Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return Ok(new FileResponse
        {
            FileName = fileName,
            ContentType = file.ContentType,
            FileContent = System.IO.File.ReadAllBytes(filePath)
        });
    }
}*/

