using System.Collections;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Http;

using Services.Abstractions;

namespace Services;

public class FileService : IFileService
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
	private static readonly string[] ImageAllowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

	public async Task<string> FileManage(IFormFile file, string folder)
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

			throw new Exception($"The folder '{folder}' is not allowed. Only 'Documents' and 'Images' are allowed.");

		if (file.Length > FileSizeLimit)
		{
			long fileSize = file.Length / 1024;
			long FileLarger = fileSize - FileSizeLimit / 1024;
			throw new Exception($"The file size {fileSize}kb exceeds the file size limit of {FileSizeLimit / 1024 / 1024}mb by {FileLarger}kb.");
		}
		var extension = Path.GetExtension(file.FileName);
		if (!((IList)AllowedExtensions).Contains(extension))
			throw new Exception($"The file '{file.FileName}' has the not allowed extension '{extension}'. Only  '{string.Join(", ", AllowedExtensions)}' are allowed.");
		if (file.Length == 0)
			throw new Exception("File is empty");
		var folderName = Path.Combine("Resources", folder);
		var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
		var name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
		if (name == null)
			throw new Exception("File is empty");
		var fileName = name.Trim('"');
		var fullPath = Path.Combine(pathToSave, fileName);
		using (var stream = new FileStream(fullPath, FileMode.Create))
			await file.CopyToAsync(stream).ConfigureAwait(false);
		return Path.Combine(folderName, fileName);
	}

	public async Task<IList<string>> MultipleFilesManage(IFormFileCollection files, string folder)
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
			throw new Exception("Invalid folder");

		if (files.Any(f => f.Length == 0))
			throw new Exception("A file is empty");

		long totalFilesLength = 0;
		foreach (var file in files)
			totalFilesLength += file.Length;

		if (totalFilesLength > FileSizeLimit)
		{
			long fileSize = totalFilesLength / 1024;
			long FileLarger = fileSize - FileSizeLimit / 1024;
			throw new Exception($"The file size {fileSize}kb exceeds the file size limit of {FileSizeLimit / 1024 / 1024}mb by {FileLarger}kb.");
		}

		string extension;
		foreach (var file in files)
		{
			extension = Path.GetExtension(file.FileName);
			if (!((IList)AllowedExtensions).Contains(extension))
				throw new Exception($"The file '{file.FileName}' has the not allowed extension '{extension}'. Only  '{string.Join(", ", AllowedExtensions)}' are allowed.");
		}

		var folderName = Path.Combine("Resources", folder);
		var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
		if (totalFilesLength == 0)
			throw new Exception("No files were uploaded");

		IList<string> fileList = new List<string>();
		foreach (var file in files)
		{
			var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim('"');
			if (fileName == null)
				throw new Exception("Filename not found");
			var fullPath = Path.Combine(pathToSave, fileName);
			fileList.Add(Path.Combine(folderName, fileName));

			using (var stream = new FileStream(fullPath, FileMode.Create))
				file.CopyTo(stream);
		}

		return fileList;
	}
}