using TexFileProcessor.Core.Models;

namespace TexFileProcessor.Core.Interfaces
{
    public interface IProcessedFileRepository
    {
        bool Add(ProcessedFileDto model);
    }
}
