using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace IntegratedProtection.Application.Helpers;
public static class FileValidator
{
    // allowed is 4 MB => 
    private const long _allowedSize = 1024 * 1024 * 4;
    private static string[] _allowedExtenstions = { ".jpg", ".png", ".jpeg" };

    public static bool IsValidByteArray(this byte[] target, IFormFile formFile) =>
        (
        _allowedSize >= target.Length
        &&
        _allowedExtenstions.Contains(Path.GetExtension(formFile.FileName).ToLower())
        ) ? true : false;
}
public static class Converter
{
    public static async Task<KeyValuePair<byte[], bool>> ToByteArray(this IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);

        var key = memoryStream.ToArray();

        var state = key.IsValidByteArray(formFile);

        IDictionary<byte[], bool> byteArrayWithState = new Dictionary<byte[], bool>() { { key, state } };

        return byteArrayWithState.FirstOrDefault();
    }

    public static byte[] ToUnSignedIntegerArray(this byte[] target)
    {
        // => Convert From Byte Array to Base64String
        string base64String = Convert.ToBase64String(target);

        // => Convert From Base64String-digits to an equivalent 8-bit
        var unSignedIntegerArray = Convert.FromBase64String(base64String);

        return unSignedIntegerArray;
    }
}
public static class Store
{
    private const string _storagePath =
        @"D:\Ahmed\Projects C#\Web API Projects\School\School.API\wwwroot\Images\";
    public static string ToStorage(this IFormFile formFile, byte[] target)
    {
        string filePath = Path.Combine(_storagePath, formFile.FileName);

        File.WriteAllBytes(filePath, target.ToUnSignedIntegerArray());

        return filePath;
    }
    public static IFormFile ReadFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            return null;
        }

        using var fileStream = File.OpenRead(filePath);

        IFormFile formFile = new FormFile(
            fileStream,
            0,
            fileStream.Length,
            null,
            Path.GetFileName(fileStream.Name))
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/*"
        };
        return formFile;
    }

    public static void DeleteFile(this string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    public static void DeleteAllFiles(this IQueryable<string> paths)
    {
        foreach (var path in paths)
            DeleteFile(path);
    }
}