using System.Text.Json.Serialization;

namespace F1FantasyLibrary.DataTransferObjects
{
    public class CreateConstructorDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
