using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Entities
{
    public class TextFile : BaseEntity
    {
        public string FileName { get; set; }
        public DateTime UploadedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
