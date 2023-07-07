using Microsoft.AspNetCore.Http;

namespace IntegratedProtection.Application.IHelpers;

public interface IFileHelper
{
    Task<string> ReadFileAsBase64(string fullPath);
    Task<string> ReadFileAsBase64(byte[] target);
    Task<byte[]> ToByteArray(IFormFile file);
    Task DeleteFile(string fullPath);
    Task ToStorage(IFormFile file, string path);
}
