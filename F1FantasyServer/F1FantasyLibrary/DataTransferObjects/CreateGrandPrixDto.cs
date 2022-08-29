using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1FantasyLibrary.DataTransferObjects
{
    public class CreateGrandPrixDto
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<int> Results { get; set; } = new List<int>();
    }
}
