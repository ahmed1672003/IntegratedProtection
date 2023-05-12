namespace IntegratedProtection.Application.IHelpers;

public interface IFileHelper
{
    bool IsValidFile(byte[] target, IFormFile file);
    Task<byte[]> ToByteArray(IFormFile file);
}
