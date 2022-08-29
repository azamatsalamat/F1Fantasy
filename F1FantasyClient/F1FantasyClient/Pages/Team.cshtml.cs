using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace F1FantasyClient.Pages
{
    public class TeamModel : PageModel
    {
        private readonly HttpClient _client;
        public JObject Team { get; set; }
        public JArray TeamGrandPrix { get; set; }

        public TeamModel(HttpClient client)
        {
            _client = client;
        }

        public async Task<JObject> GetTeam(int id)
        {
            var response = await _client.GetAsync("https://localhost:7232/api/Team/id/" + id);
            var result = await response.Content.ReadAsStringAsync();

            return JObject.Parse(result);
        }

        public async Task<JArray> GetTeamGrandPrix(int id)
        {
            var response = await _client.GetAsync("https://localhost:7232/api/GrandPrix/team/" + id);
            var result = await response.Content.ReadAsStringAsync();

            return JArray.Parse(result);
        }

        public void OnGet(int id)
        {
            Team = GetTeam(id).Result;
            TeamGrandPrix = GetTeamGrandPrix(id).Result;
        }
    }
}
