using FileUpload.Entities;

namespace FileUpload.Repositories.Interfaces
{
    public interface ITextFileRepository
    {
        Task SaveChangesAsync();
        Task<TextFile> Add(TextFile entity);
        Task<List<TextFile>> GetAllTextFilesAsync();
        Task<Guid> GetLatestTextFileIdAsync();
    }
}
