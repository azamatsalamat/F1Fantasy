using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace F1FantasyLibrary
{
    public class GrandPrixResultsModel
    {
        public int Id { get; set; }
        public int GrandPrixId { get; set; }
        [JsonIgnore]
        public GrandPrixModel GrandPrix { get; set; }
        public int RacerId { get; set; }
        public RacerModel Racer { get; set; }
        public int Position { get; set; } = 0;
        public int Points { get; set; } = 0;
    }
}
