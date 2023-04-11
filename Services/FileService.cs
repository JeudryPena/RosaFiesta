using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.Net.Http.Headers;
using Contracts.Model.Enterprise.Response;
using Microsoft.AspNetCore.Http;
using Services.Abstractions;

namespace Services;

public class FileService: IFileService
{
     private const long PdfFileSizeMb = 2;
    private const long PdfFileSizeLimit = 1024 * 1024 * PdfFileSizeMb;
    private const long PdfTotalSizesMb = 10;
    private const long PdfTotalSizesLimit = 1024 * 1024 * PdfTotalSizesMb;
    private static readonly string[] PdfAllowedExtensions = { ".pdf" };
    private const long ImageFileSizeMb = 2;
    private const long ImageFileSizeLimit = 1024 * 1024 * ImageFileSizeMb;
    private const long ImageTotalSizesMb = 10;
    private const long ImageTotalSizesLimit = 1024 * 1024 * ImageTotalSizesMb;
    private static readonly string[] ImageAllowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp"  };
    private List<string> _BackgroundColours = new List<string> { "FF0000", "FF7F00", "FFFF00", "00FF00", "0000FF", "4B0082", "8B00FF" };
    
    public async Task<FileResponse> FileManage(IFormFile file, string folder)
    {
        long FileSizeLimit;
        string[] AllowedExtensions;
        if (folder == "Documents")
        {
            FileSizeLimit = PdfFileSizeLimit;
            AllowedExtensions = PdfAllowedExtensions;
        }
        else if (folder == "Images")
        {
            FileSizeLimit = ImageFileSizeLimit;
            AllowedExtensions = ImageAllowedExtensions;
        }
        else
        {
            return new FileResponse
            {
                isSuccesful = false,
                Message = "Invalid folder"
            };
        }

        if (file.Length > FileSizeLimit)
        {
            long fileSize = file.Length / 1024;
            long FileLarger = fileSize - FileSizeLimit / 1024;
            return new FileResponse
            {
                Message = $"The file size {fileSize}kb exceeds the file size limit of {FileSizeLimit / 1024 / 1024}mb by {FileLarger}kb.",
                isSuccesful = false
            };
        }

        var extension = Path.GetExtension(file.FileName);
        if (!((IList)AllowedExtensions).Contains(extension))
        {
            return new FileResponse
            {
                Message = $"The file '{file.FileName}' has the not allowed extension '{extension}'. Only  '{string.Join(", ", AllowedExtensions)}' are allowed.",
                isSuccesful = false
            };
        }
        if (file.Length > 0)
        {
            var folderName = Path.Combine("Resources", folder);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
            if (name != null)
            {
                var fileName = name.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream).ConfigureAwait(false);
                }
                return new FileResponse
                {
                    FileId = Guid.NewGuid(),
                    Message = "File Uploaded Successfully",
                    isSuccesful = true,
                    FileUrl = fullPath,
                    FileName = fileName,
                    FileSize = file.Length,
                    FileExtension = extension,
                    ContentType = file.ContentType,
                    FileContent = File.ReadAllBytes(fullPath),
                    FileLocation = folderName, 
                    ContentDisposition =  file.ContentDisposition,
                    FileDescription = file.FileName,
                    FileDate = DateTimeOffset.Now,
                };
            }
        }
        {
            return new FileResponse
            {
                Message = "The file is empty.",
                isSuccesful = false
            };
        }
    }

    public async Task<MultipleFilesResponse> MultipleFilesManage(IFormFileCollection files, string folder)
    {
        long FileSizeLimit;
        string[] AllowedExtensions;
        if (folder == "Documents")
        {
            FileSizeLimit = PdfTotalSizesLimit;
            AllowedExtensions = PdfAllowedExtensions;
        }
        else if (folder == "Images")
        {
            FileSizeLimit = ImageTotalSizesLimit;
            AllowedExtensions = ImageAllowedExtensions;
        }
        else
        {
            return new MultipleFilesResponse
            {
                isSuccesful = false,
                Message = "Invalid folder"
            };
        }

        long totalFilesLength = 0;
        foreach (var file in files)
        {
            totalFilesLength += file.Length;
        }
            
        if(totalFilesLength > FileSizeLimit)
        {
            long fileSize = totalFilesLength / 1024;
            long FileLarger = fileSize - FileSizeLimit / 1024;
            return new MultipleFilesResponse 
            {
                Message = $"The file size {fileSize}kb exceeds the file size limit of {FileSizeLimit / 1024 / 1024}mb by {FileLarger}kb.",
                isSuccesful = false
            };
        }

        string extension;
        foreach (var file in files)
        {
            extension = Path.GetExtension(file.FileName);
            if (!((IList)AllowedExtensions).Contains(extension))
            {
                return new MultipleFilesResponse
                {
                    Message = $"The file '{file.FileName}' has the not allowed extension '{extension}'. Only  '{string.Join(", ", AllowedExtensions)}' are allowed.",
                    isSuccesful = false
                };
            }
        }

        var folderName = Path.Combine("Resources", folder);
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        if (totalFilesLength == 0)
        {
            return new MultipleFilesResponse
            {
                Message = "No files were uploaded",
                isSuccesful = false
            };
        }

        string[] dbPath = Array.Empty<string>();
        foreach (var file in files)
        {
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
                
            // dbpath dbPath += Path.Combine(folderName, fileName);
            ((IList)dbPath).Add(Path.Combine(folderName, fileName));

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            
        }

        return new MultipleFilesResponse
        {
            Message = "Files Uploaded Successfully",
            isSuccesful = true,
        };
    }
    
    public string GenerateCircle(string candidateName)
    {
        try
        {
            var initialsplit = candidateName.Split(' ').Select(x => x[0]).Take(2).ToArray();
            var initials = new string(initialsplit).ToUpper(CultureInfo.CurrentCulture);
            
            const int width = 200;
            const int height = 200; 
            var bmp = new Bitmap(width, height);
            var graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            //graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graph.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            //graph.TextRenderingHint = TextRenderingHint.AntiAlias;
            var rect = new Rectangle(0, 0, width, height);
            var rnd = new Random();
            var color = ColorTranslator.FromHtml("#" + _BackgroundColours[rnd.Next(0, _BackgroundColours.Count)]);
            //graph.Clear(color);
            graph.Clear(Color.Transparent);
            graph.FillRectangle(new SolidBrush(color), rect);
            //graph.FillEllipse(new SolidBrush(color), rect);
            //graph.FillEllipse(new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))), rect);
            var font = new Font("Arial", 72, FontStyle.Bold, GraphicsUnit.Pixel);
            var size = graph.MeasureString(initials, font);
            var x = (width - size.Width) / 2;
            var y = (height - size.Height) / 2;
            graph.DrawString(initials, font, new SolidBrush(Color.WhiteSmoke), x, y);
            graph.Flush();
            // save image in file
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = candidateName + ".png";
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            bmp.Save(fullPath, ImageFormat.Png);
            bmp.Dispose();
            return dbPath;
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(string.Join(", ", e));;
        }
    }
}