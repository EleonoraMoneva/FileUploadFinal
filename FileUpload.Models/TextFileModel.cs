using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Models
{
    public class TextFileModel
    {
        public string FileName { get; set; }
        public DateTime UploadedOn { get; set; }
        public TextFileModel(string fileName, DateTime uploadedOn)
        {
            FileName = fileName;
            UploadedOn = uploadedOn;
        }


    }
}
