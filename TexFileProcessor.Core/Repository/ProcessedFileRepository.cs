using AutoMapper;
using Microsoft.Extensions.Logging;
using TexFileProcessor.Core.Interfaces;
using TexFileProcessor.Core.Models;
using TextFileProcessor.Data;
using TextFileProcessor.Data.DataModel;

namespace TexFileProcessor.Core.Repository
{
    public class ProcessedFileRepository : IProcessedFileRepository
    {
        private readonly TextFileProcessorDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProcessedFileRepository> _logger;
        public ProcessedFileRepository(TextFileProcessorDbContext context, IMapper mapper, ILogger<ProcessedFileRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public bool Add(ProcessedFileDto model)
        {
            try
            {
                var entity = _mapper.Map<ProcessedFileDto, ProcessedFileModel>(model);

                _context.ProcessedFiles.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            
        }
    }
}
