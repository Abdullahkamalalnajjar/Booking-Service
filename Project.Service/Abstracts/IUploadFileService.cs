namespace Project.Service.Abstracts
{
    public interface IUploadFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);
    }
}