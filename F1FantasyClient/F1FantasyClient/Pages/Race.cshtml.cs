using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace F1FantasyClient.Pages
{
    public class RaceModel : PageModel
    {
        private readonly HttpClient _client;
        public JObject GrandPrix { get; set; }

        public RaceModel(HttpClient client)
        {
            _client = client;
        }

        public async Task<JObject> GetObject (int id)
        {
            var response = await _client.GetAsync("https://localhost:7232/api/GrandPrix/" + id);
            var result = await response.Content.ReadAsStringAsync();

            return JObject.Parse(result);
        }

        public void OnGet(int id)
        {
            GrandPrix = GetObject(id).Result;
        }
    }
}
