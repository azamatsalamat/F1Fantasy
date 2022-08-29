using F1FantasyLibrary.FileModels;
using System.Text.Json.Serialization;

namespace F1FantasyLibrary
{
    public class ConstructorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public ConstructorFileModel Logo { get; set; }
        public List<RacerModel> Racers { get; set; }
        [JsonIgnore]
        public List<TeamModel> Teams { get; set; } = new List<TeamModel>();
    }
}
