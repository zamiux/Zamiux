namespace Zamiux.Web.Utils.ImageHandler
{
    public static class FileExtensions
    {
        public static void AddImageToServer(this IFormFile image, string fileName, string originalPath, int? width, int? height, string thumbPath = null, string deletefileName = null, bool checkImageContent = true)
        {
            if (image != null && image.IsImage(checkImageContent))
            {
                if (!Directory.Exists(originalPath))
                    Directory.CreateDirectory(originalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(originalPath + deletefileName))
                        File.Delete(originalPath + deletefileName);

                    if (!string.IsNullOrEmpty(thumbPath))
                    {
                        if (File.Exists(thumbPath + deletefileName))
                            File.Delete(thumbPath + deletefileName);
                    }
                }

                string finalPath = originalPath + fileName;

                using (var stream = new FileStream(finalPath, FileMode.Create))
                {
                    if (!Directory.Exists(finalPath)) image.CopyTo(stream);
                }

                if (!string.IsNullOrEmpty(thumbPath))
                {
                    if (!Directory.Exists(thumbPath))
                        Directory.CreateDirectory(thumbPath);

                    ImageOptimizer resizer = new ImageOptimizer();

                    if (width != null && height != null)
                        resizer.ImageResizer(originalPath + fileName, thumbPath + fileName, width, height);
                }
            }
        }

        public static void DeleteImage(this string imageName, string OriginPath, string? ThumbPath)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                if (File.Exists(OriginPath + imageName))
                    File.Delete(OriginPath + imageName);

                if (!string.IsNullOrEmpty(ThumbPath))
                {
                    if (File.Exists(ThumbPath + imageName))
                        File.Delete(ThumbPath + imageName);
                }
            }
        }
    }
}
