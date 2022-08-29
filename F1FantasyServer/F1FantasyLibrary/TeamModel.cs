using System.Text.Json.Serialization;

namespace F1FantasyLibrary
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; } = 0;
        public double Points { get; set; } = 0;
        public double CurrentCost { get; set; }
        public List<RacerModel> Racers { get; set; } = new List<RacerModel>();
        public List<ConstructorModel> Constructors { get; set; } = new List<ConstructorModel>();
        public List<GrandPrixTeamResultModel> Results { get; set; } = new List<GrandPrixTeamResultModel>();
    }
}
