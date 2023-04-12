using Microsoft.EntityFrameworkCore;
using TextFileProcessor.Data.DataModel;

namespace TextFileProcessor.Data
{
    public class TextFileProcessorDbContext : DbContext
    {
        public TextFileProcessorDbContext(DbContextOptions<TextFileProcessorDbContext> options) : base(options)
        {
        }

        public DbSet<ProcessedFileModel> ProcessedFiles { get; set; }
    }
}
