using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1FantasyLibrary.DataTransferObjects
{
    public class AddRacerToTeamDto
    {
        public int TeamId { get; set; }
        public int RacerId { get; set; }
    }
}
