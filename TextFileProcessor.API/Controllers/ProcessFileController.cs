using Microsoft.AspNetCore.Mvc;
using TexFileProcessor.Core.Interfaces;

namespace TextFileProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessFileController : ControllerBase
    {
        private readonly IFileProcessorServices _fileProcessorServices;
        private readonly ILogger<ProcessFileController> _logger;
        public ProcessFileController(IFileProcessorServices fileProcessorServices)
        {
            _fileProcessorServices = fileProcessorServices;
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
    }
}
