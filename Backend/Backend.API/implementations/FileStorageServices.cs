using Microsoft.AspNetCore.Http;
using System.IO;          
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;
namespace Backend.API 
{
    public class FileStorageServices : IFileStorageServices
    {
        private readonly IWebHostEnvironment _env;
        public FileStorageServices(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            if (file == null)
            {
                return null;
            }
            var rootPath = _env.WebRootPath;
            if (string.IsNullOrEmpty(rootPath))
            {
                rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            var folderPath = Path.Combine(rootPath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var extension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/{folderName}/{uniqueFileName}";
        }
    }
}
