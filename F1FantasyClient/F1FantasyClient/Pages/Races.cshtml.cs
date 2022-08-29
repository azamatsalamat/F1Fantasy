using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace F1FantasyClient.Pages
{
    public class RacesModel : PageModel
    {
        private readonly HttpClient _client;
        public JArray Races { get; set; }

        public RacesModel(HttpClient client)
        {
            _client = client;
        }

        public async Task<JArray> GetObject()
        {
            var response = await _client.GetAsync("https://localhost:7232/api/GrandPrix");
            var result = await response.Content.ReadAsStringAsync();

            return JArray.Parse(result);
        }

        public void OnGet()
        {
            Races = GetObject().Result;
        }
    }
}
