using AutoMapper;
using FileUpload.Entities;
using FileUpload.Models;

namespace FileUpload.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UploadFile, UploadFileModel>();
            CreateMap<TextFile, TextFileModel>();

        }
    }
}