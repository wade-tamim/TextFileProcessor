using AutoMapper;
using TexFileProcessor.Core.Models;
using TextFileProcessor.Data.DataModel;

namespace TexFileProcessor.Core.AutoMapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<ProcessedFileDto, ProcessedFileModel>();
        }
    }
}
