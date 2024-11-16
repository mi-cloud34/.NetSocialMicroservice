using Microsoft.AspNetCore.Http;

namespace Social.Shared.FileShared;

public interface IStorage
{
    Task<List<(string fileName, string pathOrContainerName)>> UploadsAsync(string pathOrContainerName, IFormFileCollection files);
    Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file);

    Task DeleteAsync(string pathOrContainerName, string fileName);
    List<string> GetByNameFilesAsync(string pathOrContainerName);
    Task<string> GetByNameFileAsync(string pathOrContainerName, string fileName);
    //Task<(string fileName, string pathOrContainerName)> GetByNameFilesAsync(string pathOrContainerName, string fileName);
    //Task<List<T>> GetListAsync(string fileName);
    bool HasFile(string pathOrContainerName, string fileName);
}