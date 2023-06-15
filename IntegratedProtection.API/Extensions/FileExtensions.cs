namespace IntegratedProtection.API.Extensions;

public static class FileExtensions
{
    // Key => fileName , Value => Base64String
    public static async Task<string> ToStorage(this IFormFile file, IWebHostEnvironment webHostEnvironment)
    {
        //Create the Directory.
        string path = Path.Combine(webHostEnvironment.WebRootPath, "Files\\");

        //Fetch the File Name.
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string fileName = $"{Guid.NewGuid().ToString()}{file.FileName}";

        //Save the File.
        using FileStream stream = new(Path.Combine(path, fileName), FileMode.Create);
        await file.CopyToAsync(stream);

        return fileName;
    }
    public static async Task<string> GetBase64String(this IFormFile file, IWebHostEnvironment webHostEnvironment)
    {
        using var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream);

        var base64String = Convert.ToBase64String(memoryStream.ToArray());

        return base64String;
    }

    public static void GetBase64StringFromPath(IWebHostEnvironment webHostEnvironment, string fileName)
    {
        string path = Path.Combine(webHostEnvironment.WebRootPath, "Files\\", fileName);

        var fileStream = File.ReadAllBytes($"");



    }
}
