using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace F1FantasyLibrary
{
    public class GrandPrixTeamResultModel
    {
        public int Id { get; set; }
        public int GrandPrixId { get; set; }
        [JsonIgnore]
        public GrandPrixModel GrandPrix { get; set; }
        public int TeamId { get; set; }
        [JsonIgnore]
        public TeamModel Team { get; set; }
        public int Points { get; set; } = 0;
    }
}
