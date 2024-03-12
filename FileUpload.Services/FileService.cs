using FileUpload.Repositories.Interfaces;
using FileUpload.Services.Interfaces;
using AutoMapper;
using FileUpload.Models;

namespace FileUpload.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly ITextFileService _textFileService;
        private readonly IMapper _mapper;

        public FileService(IFileRepository fileRepository, ITextFileService textFileService, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _textFileService = textFileService;
            _mapper = mapper;
        }

        public async Task<List<UploadFileModel>> GetChartDataAsync()
        {
            var lastUploadedTxtFileId = await _textFileService.GetLastUploadedFileIdAsync();
            var chartData = await _fileRepository.GetChartData(lastUploadedTxtFileId);
            return _mapper.Map<List<UploadFileModel>>(chartData);
        }
    }
}
