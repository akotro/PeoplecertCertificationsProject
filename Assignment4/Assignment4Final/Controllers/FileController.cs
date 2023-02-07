using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO.Questions;

namespace Assignment4Final.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
        // TODO:(akotro) Check if file already exists and if yes return the old one
        if (file == null || file.Length == 0)
            return BadRequest("No file received");

        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(folderPath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var uploadedFile = new FileDto
        {
            FileName = fileName,
            FilePath = filePath,
            Url = $"https://localhost:7196/api/File/image/{fileName}"
        };

        // TODO:(akotro) Save FileDto to database here

        // _context.UploadedFiles.Add(uploadedFile);

        // await _context.SaveChangesAsync();

        return Ok(uploadedFile);
    }

    [HttpGet("download/{fileName}")]
    public IActionResult DownloadFile(string fileName)
    {
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        string filePath = Path.Combine(folderPath, fileName);

        if (!System.IO.File.Exists(filePath))
            return NotFound();

        var stream = new FileStream(filePath, FileMode.Open);
        return File(stream, "application/octet-stream", fileName);
    }

    [HttpGet("image/{fileName}")]
    public IActionResult GetImage(string fileName)
    {
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        string filePath = Path.Combine(folderPath, fileName);

        if (!System.IO.File.Exists(filePath))
            return NotFound();

        var imageBytes = System.IO.File.ReadAllBytes(filePath);
        var contentType = GetContentType(filePath);

        return File(imageBytes, contentType);
    }

    private string GetContentType(string filePath)
    {
        string contentType;
        switch (Path.GetExtension(filePath).ToLower())
        {
            case ".jpg":
            case ".jpeg":
                contentType = "image/jpeg";
                break;
            case ".png":
                contentType = "image/png";
                break;
            case ".gif":
                contentType = "image/gif";
                break;
            default:
                contentType = "application/octet-stream";
                break;
        }

        return contentType;
    }
}
