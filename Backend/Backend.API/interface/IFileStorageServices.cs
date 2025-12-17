namespace Backend.API
{
    public interface IFileStorageServices
    {
        public Task<string> SaveFileAsync(IFormFile file, string folderName);
    }
}