using FileUpload.Entities;

namespace FileUpload.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task SaveChangesAsync();
        Task<UploadFile> Add(UploadFile entity);
        Task<List<UploadFile>> GetChartData(Guid textFileId);
    }
}
