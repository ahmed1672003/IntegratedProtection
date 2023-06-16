namespace IntegratedProtection.API.Extensions;

public static class FileExtensions
{
    public static async Task<string> ToStorage(this IFormFile file, IWebHostEnvironment webHostEnvironment)
    {
        //Create the Directory.
        string storagePath = Path.Combine(webHostEnvironment.WebRootPath, @"Files\");

        //Fetch the File Name.
        if (!Directory.Exists(storagePath))
            Directory.CreateDirectory(storagePath);

        string fileName = $"{Guid.NewGuid().ToString()}{file.FileName}";

        // create fullPath 
        string fullPath = Path.Combine(storagePath, fileName);

        //Save the File.
        using FileStream stream = new(fullPath, FileMode.Create);

        await file.CopyToAsync(stream);

        return fullPath;
    }
}
