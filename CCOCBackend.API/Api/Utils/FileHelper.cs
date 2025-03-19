using MCMS.Files.Models;

namespace CCOCBackend.API.Api.Utils;

public static class FileHelper
{
    public static string GetImagePath(FileEntity image)
    {
        return Path.Combine("/content", image.VirtualPath, image.Name + image.Extension).Replace("\\", "/");
    }
}