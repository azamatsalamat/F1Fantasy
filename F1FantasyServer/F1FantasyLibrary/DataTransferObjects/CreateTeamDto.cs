using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace F1FantasyLibrary.DataTransferObjects
{
    public class CreateTeamDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
