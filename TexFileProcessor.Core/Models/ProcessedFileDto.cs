using System.ComponentModel.DataAnnotations;

namespace TexFileProcessor.Core.Models
{
    public class ProcessedFileDto
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileExtension { get; set; }
        [Required]
        public int WordsCount { get; set; }
        [Required]
        public string MostFrequentWord { get; set; }
        [Required]
        public int MostFrequentWordCount { get; set; }
    }
}
