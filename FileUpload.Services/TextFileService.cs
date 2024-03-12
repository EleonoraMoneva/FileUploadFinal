using AutoMapper;
using FileUpload.Entities;
using FileUpload.Models;
using FileUpload.Repositories.Interfaces;
using FileUpload.Services.Interfaces;
using Microsoft.AspNetCore.Http;


namespace FileUpload.Services
{
    public class TextFileService : ITextFileService
    {
        private readonly ITextFileRepository _textFileRepository;
        private readonly IFileRepository _fileUploadRepository;
        private readonly IMapper _mapper;

        public TextFileService(ITextFileRepository textFileRepository, IFileRepository fileUploadRepository, IMapper mapper)
        {
            _textFileRepository = textFileRepository;
            _fileUploadRepository = fileUploadRepository;
            _mapper = mapper;
        }

        public async Task<bool> ProcessTextFileAsync(IFormFile file)
        {
            try
            {
                var textFileModel = new TextFile
                {
                    FileName = Path.GetFileNameWithoutExtension(file.FileName),  
                    UploadedOn = DateTime.Now  
                };

                var fileUploadList = new List<UploadFile>();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var values = line?.Split(',');

                        if (values.Length == 3)
                        {
                            var uploadFileModel = new UploadFile
                            {
                                Color = values[0].Trim(),
                                Number = int.Parse(values[1].Trim()),
                                Label = values[2].Trim()
                            };
                            if (ValidateUploadFileModel(uploadFileModel))
                            {
                                fileUploadList.Add(uploadFileModel);
                            }
                        }
                    }
                }

                if (fileUploadList.Count > 0)
                {
                    await _textFileRepository.Add(textFileModel);
                    await _textFileRepository.SaveChangesAsync();

                    foreach (var uploadFileModel in fileUploadList)
                    {
                        var uploadFileEntity = _mapper.Map<UploadFile>(uploadFileModel);
                        uploadFileEntity.TextFileId = textFileModel.Id; 
                        await _fileUploadRepository.Add(uploadFileEntity);
                    }
                    await _fileUploadRepository.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<TextFileModel>> GetAllTextFilesAsync()
        {
            var textFileEntities = await _textFileRepository.GetAllTextFilesAsync();
            return _mapper.Map<List<TextFileModel>>(textFileEntities);
        }

        public async Task<Guid> GetLastUploadedFileIdAsync()
        {
            return await _textFileRepository.GetLatestTextFileIdAsync();
        }
        private bool ValidateUploadFileModel(UploadFile model)
        {
            return !string.IsNullOrWhiteSpace(model.Color) &&
                   model.Number > 0 &&
                   !string.IsNullOrWhiteSpace(model.Label);
        }
    }
}
