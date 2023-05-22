
using IntegratedProtection.Application.IHelpers;

namespace IntegratedProtection.API.Helpers;

public class FilesHelper : IFileHelper
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FilesHelper(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<byte[]> ToByteArray(IFormFile file)
    {
        using var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream);

        return memoryStream.ToArray();
    }

    public bool IsValidFile(byte[] target, IFormFile file)
    {
        var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
        var allowedSize = 1024 * 1024 * 5;
        return
            allowedExtensions.Contains(Path.GetExtension(file.FileName))
            &&
            allowedSize >= target.Length;
    }
}
