using FileUpload.Models;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Services.Interfaces
{
    public interface ITextFileService
    {
        Task<bool> ProcessTextFileAsync(IFormFile file);
        Task<List<TextFileModel>> GetAllTextFilesAsync();
        Task<Guid> GetLastUploadedFileIdAsync();

    }
}
