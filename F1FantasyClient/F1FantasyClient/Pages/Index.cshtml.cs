using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace F1FantasyClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _client;

        public IndexModel(HttpClient client)
        {
            _client = client;
        }

        public JArray Teams { get; set; }

        public async Task<JArray> GetObject()
        {
            var response = await _client.GetAsync("https://localhost:7232/api/Team");
            var result = await response.Content.ReadAsStringAsync();

            return JArray.Parse(result);
        }

        public async void OnGet()
        {
            Teams = GetObject().Result;
        }
    }
}