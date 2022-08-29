using System.Text.Json.Serialization;

namespace F1FantasyLibrary.FileModels
{
    public class ConstructorFileModel : FileModel
    {
        public int ConstructorId { get; set; }
        [JsonIgnore]
        public ConstructorModel Constructor { get; set; }
    }
}
