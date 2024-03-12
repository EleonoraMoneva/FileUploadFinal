using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using FileUpload.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet("chartData")]
    public async Task<IEnumerable<UploadFileModel>> GetChartData()
    {
        var chartData = await _fileService.GetChartDataAsync();
        return chartData;



    }
}