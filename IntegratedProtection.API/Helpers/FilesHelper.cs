namespace IntegratedProtection.API.Helpers;

public class FilesHelper : IFileHelper
{
    private readonly IWebHostEnvironment _environment;

    public FilesHelper(IWebHostEnvironment environment) => _environment = environment;

    public Task DeleteFile(string fullPath)
    {
        if (File.Exists(fullPath))
            File.Delete(fullPath);

        return Task.CompletedTask;
    }

    public async Task<string> ReadFileAsBase64(string fullPath)
    {
        if (!File.Exists(fullPath))
            return string.Empty;

        var fileBytes = File.ReadAllBytes(fullPath);

        var base64 = Convert.ToBase64String(fileBytes);

        return await Task.FromResult(base64);
    }

    public async Task ToStorage(IFormFile file, string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
    }
}
