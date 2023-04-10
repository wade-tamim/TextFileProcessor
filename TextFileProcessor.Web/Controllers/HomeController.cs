using Microsoft.AspNetCore.Mvc;
using System.IO;
using TexFileProcessor.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace TextFileProcessor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProcessorServices _fileProcessorServices;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IFileProcessorServices fileProcessorServices, ILogger<HomeController> logger)
        {
            _fileProcessorServices = fileProcessorServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest(new { errorMessage = "No file was uploaded, please upload a text file." });
            }
           
            if (!_fileProcessorServices.ValidateFile(file))
            {
                _logger.LogWarning($"Uploaded unvalid type: {Path.GetExtension(file.FileName)}.");
                return BadRequest(new { errorMessage = "Invalid file type. Please upload a text file, RTF file, or markdown file." });
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
