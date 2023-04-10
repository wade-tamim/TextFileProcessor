namespace TexFileProcessor.Core.Models
{
    public class ProcessedFileVieModel
    {
        public int? WordsCount { get; set; }
        public string? MostFrequentWord { get; set; }
        public int? MostFrequentWordCount { get; set; }
        public string? ProcessedText { get; set; }
        public string? ErrorMessage { get; set; }
        public bool ProcessSuccess { get; set; }

    }
}
