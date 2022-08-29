using System.Text.Json.Serialization;

namespace F1FantasyLibrary.FileModels
{
    public class RacerFileModel : FileModel
    {
        public int RacerId { get; set; }
        [JsonIgnore]
        public RacerModel Racer { get; set; }
    }
}
