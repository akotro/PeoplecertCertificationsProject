using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO.Questions;

namespace Assignment4Final.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
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

        var uploadedFile = new FileDto { FileName = file.FileName, FilePath = filePath };

        // TODO:(akotro) Save FileDto to database here

        // _context.UploadedFiles.Add(uploadedFile);

        // await _context.SaveChangesAsync();

        return Ok(uploadedFile);
    }
}
