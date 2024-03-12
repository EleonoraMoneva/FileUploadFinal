using FileUpload.Context;
using FileUpload.Entities;
using FileUpload.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileUploadDbContext _context;
        private DbSet<UploadFile> _set;

        public FileRepository(FileUploadDbContext context)
        {
            _context = context;
            _set = context.Set<UploadFile>();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<UploadFile> Add(UploadFile entity)
        {
            var e = _set.Add(entity);
            return e.Entity;
        }

        public async Task<List<UploadFile>> GetChartData(Guid textFileId)
        {
            return await _set.Where(s => s.TextFileId == textFileId).ToListAsync();
        }
    }
}
