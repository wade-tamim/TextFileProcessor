using Microsoft.AspNetCore.Http;
using TexFileProcessor.Core.Models;

namespace TexFileProcessor.Core.Interfaces
{
    public interface IFileProcessorServices
    {
        bool ValidateFile(IFormFile file);
        ProcessedFileVieModel ProcessFile(IFormFile file);
    }
}
