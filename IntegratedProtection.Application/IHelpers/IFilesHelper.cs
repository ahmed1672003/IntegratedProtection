namespace IntegratedProtection.Application.IHelpers;

public interface IFileHelper
{
    Task<string> ReadFileAsBase64(string fullPath);
    Task DeleteFile(string fullPath);
    Task ToStorage(IFormFile file, string path);
}
