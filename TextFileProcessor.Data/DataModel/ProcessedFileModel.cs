namespace TextFileProcessor.Data.DataModel
{
    public class ProcessedFileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int WordsCount { get; set; }
        public string MostFrequentWord { get; set; }
        public int MostFrequentWordCount { get; set; }
    }
}
