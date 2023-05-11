
using IntegratedProtection.Application.IHelpers;

namespace IntegratedProtection.API.Helpers;

public class FilesHelper<TEntity> : IFileHelper<TEntity> where TEntity : class
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FilesHelper(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> ToStore(IFormFile file)
    {
        string s = _webHostEnvironment.WebRootPath + "/" + "images";
        string folderPath = Path.Combine(s, $"{typeof(TEntity).Name}");

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string filePath = string.Concat(folderPath, Guid.NewGuid().ToString(), "_", file.FileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);

        await file.CopyToAsync(fileStream);

        return filePath;
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

}
