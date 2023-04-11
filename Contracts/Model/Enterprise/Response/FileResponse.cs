namespace Contracts.Model.Enterprise.Response;

public class FileResponse
{
    public Guid FileId { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] FileContent { get; set; }
    public string FileExtension { get; set; }
    public string FileLocation { get; set; }
    public string FileUrl { get; set; }
    public long FileSize { get; set; }
    public string ContentDisposition { get; set; }
    public DateTimeOffset FileDate { get; set; }
    public string FileDescription { get; set; }
    public bool isSuccesful { get; set; }
    public string Message { get; set; }
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

