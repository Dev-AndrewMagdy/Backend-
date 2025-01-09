namespace TamayouzAPI.Helper
{
    public class ImagesProvider(IWebHostEnvironment webHostEnvironment)
    {
        public async Task<string?> SaveFileAsync(IFormFile? imageFile, string[] allowedFileExtensions)
        {
            if (imageFile == null)
            {
                return null;
            }

            if (imageFile?.Length > 2 * 1024 * 1024)
            {
                throw new ArgumentException("File size should not exceed 2 MB");
            }

            var contentPath = webHostEnvironment.WebRootPath;
            var path = Path.Combine(contentPath, "uploads");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Check the allowed extenstions
            var ext = Path.GetExtension(imageFile.FileName);
            if (!allowedFileExtensions.Contains(ext))
            {
                throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");
            }

            // generate a unique filename
            var fileName = $"{Guid.NewGuid().ToString()}{ext}";
            var fileNameWithPath = Path.Combine(path, fileName);
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await imageFile.CopyToAsync(stream);
            return fileName;
        }

        public void DeleteFile(string fileNameWithExtension)
        {
            if (string.IsNullOrEmpty(fileNameWithExtension))
            {
                throw new ArgumentNullException(nameof(fileNameWithExtension));
            }
            var contentPath = webHostEnvironment.ContentRootPath;
            var path = Path.Combine(contentPath, $"uploads", fileNameWithExtension);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Invalid file path");
            }
            File.Delete(path);
        }
    }
}
