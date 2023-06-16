namespace IntegratedProtection.Application.IHelpers;

public interface IFileHelper
{
    string ReadFileAsBase64(string fullPath);
    void DeleteFile(string fullPath);
}
