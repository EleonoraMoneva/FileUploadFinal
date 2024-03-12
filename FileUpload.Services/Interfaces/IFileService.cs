using FileUpload.Models;

namespace FileUpload.Services.Interfaces
{
    public interface IFileService
    {
        Task<List<UploadFileModel>> GetChartDataAsync();
    }
}
