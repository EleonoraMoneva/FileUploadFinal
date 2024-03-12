using Microsoft.EntityFrameworkCore;
using FileUpload.Entities;
namespace FileUpload.Context
{
    public class FileUploadDbContext : DbContext
    {
        public DbSet<UploadFile> UploadFile { get; set; }
        public DbSet<TextFile> TextFiles { get; set; }

        public FileUploadDbContext(DbContextOptions<FileUploadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UploadFile>()
                .HasOne(u => u.TextFile)
                .WithMany()
                .HasForeignKey(u => u.TextFileId)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
