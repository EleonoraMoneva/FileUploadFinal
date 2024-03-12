namespace FileUpload.Entities
{
    public class UploadFile : BaseEntity
    {
        public Guid TextFileId { get; set; }  
        public string Color { get; set; }
        public int Number { get; set; }
        public string Label { get; set; }
        public TextFile TextFile { get; set; }
    }
}