namespace TextFileProcessor.Data.DataModels
{
    public class ProcessedFileModel
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int WordsCount { get; set; }
        public string MostFrequentWord { get; set; }
        public int MostFrequentWordCount { get; set; }
    }
}
