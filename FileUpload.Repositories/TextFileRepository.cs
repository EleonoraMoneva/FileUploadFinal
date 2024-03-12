using FileUpload.Context;
using FileUpload.Entities;
using FileUpload.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Repositories
{
    public class TextFileRepository : ITextFileRepository
    {
        private readonly FileUploadDbContext _context;
        private DbSet<TextFile> _set;

        public TextFileRepository(FileUploadDbContext context)
        {
            _context = context;
            _set = context.Set<TextFile>();
        }

        public async Task<List<TextFile>> GetAllTextFilesAsync()
        {
            return await _set.OrderByDescending(t => t.UploadedOn).ToListAsync();
        }

        public async Task<Guid> GetLatestTextFileIdAsync()
        {
            var latestFile = await _set.OrderByDescending(t => t.UploadedOn).FirstOrDefaultAsync();
            return latestFile != null ? latestFile.Id : Guid.Empty;

        }

        public async Task<TextFile> Add(TextFile entity)
        {
            var e = await _set.AddAsync(entity);
            return  e.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
