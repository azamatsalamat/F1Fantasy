using F1FantasyLibrary.FileModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace F1FantasyLibrary
{
    public class GrandPrixModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Country { get; set; } = string.Empty;
        public GrandPrixFileModel CountryFlag { get; set; }
        public List<GrandPrixResultsModel> Results { get; set; }
        public List<GrandPrixTeamResultModel> TeamResults { get; set; }
    }
}
