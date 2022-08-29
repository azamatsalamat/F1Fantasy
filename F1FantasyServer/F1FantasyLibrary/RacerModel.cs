using F1FantasyLibrary.FileModels;
using System.Text.Json.Serialization;

namespace F1FantasyLibrary
{
    public class RacerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double Price { get; set; }
        public RacerFileModel Image { get; set; }
        public int ConstructorId { get; set; }
        [JsonIgnore]
        public ConstructorModel Constructor { get; set; }
        [JsonIgnore]
        public List<TeamModel> Teams { get; set; } = new List<TeamModel>();
        [JsonIgnore]
        public List<GrandPrixModel> GrandPrix { get; set; }
    }
}