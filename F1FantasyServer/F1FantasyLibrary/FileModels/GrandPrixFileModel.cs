using System.Text.Json.Serialization;

namespace F1FantasyLibrary.FileModels
{
    public class GrandPrixFileModel : FileModel
    {
        public int GrandPrixId { get; set; }
        [JsonIgnore]
        public GrandPrixModel GrandPrix { get; set; }
    }
}
