using Microsoft.EntityFrameworkCore;
using TextFileProcessor.Data.DataModels;

namespace TextFileProcessor.Data.DbContext
{
    public class TextFileProcessorDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TextFileProcessorDbContext(DbContextOptions<TextFileProcessorDbContext> options) : base(options)
        {

        }
        public DbSet<ProcessedFileModel> ProcessedFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
