namespace FileUpload.Models
{
    public class UploadFileModel
    {
        public string Color { get; set; }
        public int Number { get; set; }
        public string Label { get; set; }
        public UploadFileModel()
        {
            Color = "";
            Number = 0;
            Label = "";

        }
        public UploadFileModel(string color, int number, string label)
        {
            Color = color;
            Number = number;
            Label = label;
        }
    }
}