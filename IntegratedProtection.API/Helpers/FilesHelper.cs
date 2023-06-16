namespace IntegratedProtection.API.Helpers;

public class FilesHelper : IFileHelper
{
    private readonly IWebHostEnvironment _environment;

    public FilesHelper(IWebHostEnvironment environment) => _environment = environment;

    public void DeleteFile(string fullPath)
    {
        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }

    public string ReadFileAsBase64(string fullPath)
    {
        if (!File.Exists(fullPath))
            return string.Empty;

        var fileBytes = File.ReadAllBytes(fullPath);
        return Convert.ToBase64String(fileBytes);
    }

    public async Task ToStorage(IFormFile file, string path)
    {
        var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
    }
}
