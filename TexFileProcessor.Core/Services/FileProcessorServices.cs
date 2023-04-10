using Microsoft.AspNetCore.Http;
using TexFileProcessor.Core.Interfaces;
using TexFileProcessor.Core.Models;

namespace TexFileProcessor.Core.Services
{
    public class FileProcessorServices : IFileProcessorServices
    {
        public bool ValidateFile(IFormFile file)
        {
            var allowedExtensions = new[] { ".txt", ".rtf", ".md", ".file"};
            var extension = Path.GetExtension(file.FileName);

            return allowedExtensions.Contains(extension.ToLower());
        }

        public ProcessedFileVieModel ProcessFile(IFormFile file)
        {
            var processedFileModel = new ProcessedFileVieModel();
            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    var fileContent = streamReader.ReadToEnd();

                    var words = fileContent.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    processedFileModel.WordsCount = words.Length;

                    var wordFrequencies = new Dictionary<string, int>();
                    foreach (var word in words)
                    {
                        if (wordFrequencies.ContainsKey(word))
                        {
                            wordFrequencies[word]++;
                        }
                        else
                        {
                            wordFrequencies.Add(word, 1);
                        }
                    }

                    var mostFrequentWord = wordFrequencies.OrderByDescending(x => x.Value).FirstOrDefault();

                    processedFileModel.MostFrequentWord = mostFrequentWord.Key;
                    processedFileModel.MostFrequentWordCount = mostFrequentWord.Value;

                    var processedText = fileContent.Replace(mostFrequentWord.Key, $"foo{mostFrequentWord.Key}bar");

                    processedFileModel.ProcessedText = processedText;
                    processedFileModel.ProcessSuccess = true;
                }
            }
            catch (Exception e)
            {
                processedFileModel.ProcessSuccess = false;
                processedFileModel.ErrorMessage = e.Message;
            }
            
            return processedFileModel;
        }
    }
}
