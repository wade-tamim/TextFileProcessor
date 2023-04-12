using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;
using TexFileProcessor.Core.Interfaces;
using TexFileProcessor.Core.Models;

namespace TextFileProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessFileController : ControllerBase
    {
        private readonly IFileProcessorServices _fileProcessorServices;
        private readonly ILogger<ProcessFileController> _logger;
        private readonly IProcessedFileRepository _processedFileRepository;
        public ProcessFileController(IFileProcessorServices fileProcessorServices, ILogger<ProcessFileController> logger, IProcessedFileRepository processedFileRepository)
        {
            _fileProcessorServices = fileProcessorServices;
            _logger = logger;
            _processedFileRepository = processedFileRepository;
        }

        [HttpPost("PostFile")]
        public async Task<IActionResult> PostFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Couldn't read file.");
            }

            if (!_fileProcessorServices.ValidateFile(file))
            {
                _logger.LogWarning($"API: Uploaded unvalid type: {Path.GetExtension(file.FileName)}.");
                return BadRequest("Couldn't validate file.");
            }

            var model = _fileProcessorServices.ProcessFile(file);

            if (model == null || !model.ProcessSuccess)
            {
                _logger.LogError(model?.ErrorMessage);
                return BadRequest(new { errorMessage = "Something went wrong, we will look into it. Try upload another file." });
            }

            return Ok(model);
        }

        [HttpPost ("SaveFileInfo")]
        [SwaggerOperation(Summary = "Saves file info", Description = "Adds information about a processed file to the database.")]

        public async Task<IActionResult> SaveFileInfo(ProcessedFileDto fileInfo)
        {
            if (fileInfo == null)
            {
                return BadRequest("needs info to save!");
            }

            if (_processedFileRepository.Add(fileInfo))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}
