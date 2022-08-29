using System.Text.Json.Serialization;

namespace F1FantasyLibrary.FileModels
{
    public class FileModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string StorageName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
