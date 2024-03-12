using FileUpload.Models;
using FileUpload.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextFileController : ControllerBase
    {
        private readonly ITextFileService _textFileService;

        public TextFileController(ITextFileService textFileService)
        {
            _textFileService = textFileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadTextFile([FromForm] IFormFile file)
        {
            var result = await _textFileService.ProcessTextFileAsync(file);
            if (result)
            {
                return Ok("Text file uploaded and processed successfully.");
            }
            else
            {
                //here we can use Azure Application Insights for logging errors and bad requests
                return BadRequest("Failed to process the text file.");
            }
        }

        [HttpGet("files")]
        public async Task<IEnumerable<TextFileModel>> GetAllTextFiles()
        {
            var textFiles = await _textFileService.GetAllTextFilesAsync();
            return textFiles;



        }
    }
}
