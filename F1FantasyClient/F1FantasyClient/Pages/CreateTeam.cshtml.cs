using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace F1FantasyClient.Pages
{
    public class CreateTeamModel : PageModel
    {
        private readonly HttpClient _client;

        public CreateTeamModel(HttpClient client)
        {
            _client = client;
        }

        public JArray Racers { get; set; }
        public JArray Constructors { get; set; }

        public async Task<JArray> GetArray(string apiUrl)
        {
            var response = await _client.GetAsync(apiUrl);
            var result = await response.Content.ReadAsStringAsync();

            return JArray.Parse(result);
        }

        public async Task<JObject> GetObject(string apiUrl)
        {
            var response = await _client.GetAsync(apiUrl);
            var result = await response.Content.ReadAsStringAsync();

            return JObject.Parse(result);
        }

        public void OnGet()
        {
            Racers = GetArray("https://localhost:7232/api/Racer").Result;
            Constructors = GetArray("https://localhost:7232/api/Constructor").Result;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToPage("/CreateTeam");
            }

            string name = Request.Form["name"];
            foreach (var team in GetArray("https://localhost:7232/api/Team/").Result)
            {
                if (team["name"].ToString() == name)
                {
                    TempData["error"] = "Name is already taken";
                    return RedirectToPage("/CreateTeam");
                }
            }

            if (Convert.ToDouble(Request.Form["cashValue"].ToString().Replace('.',',')) < 0)
            {
                TempData["error"] = "Your total cost exceeds available amount";
                return RedirectToPage("/CreateTeam");
            }

            if (Request.Form["driver1"] == Request.Form["driver2"] || Request.Form["driver2"] == Request.Form["driver3"] || Request.Form["driver1"] == Request.Form["driver3"])
            {
                TempData["error"] = "You can't choose one driver more than once";
                return RedirectToPage("/CreateTeam");
            }

            if (Request.Form["constructor1"] == Request.Form["constructor2"])
            {
                TempData["error"] = "You can't choose one constructor more than once";
                return RedirectToPage("/CreateTeam");
            }

            var cashLeft = Convert.ToDouble(Request.Form["cashValue"].ToString().Replace('.',','));

            var newTeam = new Dictionary<string, Object>
            {
                {"name", name},
                {"cost", 60-cashLeft}
            };
            var content = JsonConvert.SerializeObject(newTeam);
            await _client.PostAsync("https://localhost:7232/api/Team", new StringContent(content, Encoding.UTF8, "application/json"));


            for (int i = 1; i<4; i++)
            {
                var newRacerInTeam = new Dictionary<string, int>
                {
                    {"teamId", Int32.Parse(GetObject("https://localhost:7232/api/Team/name/" + name).Result["id"].ToString())},
                    {"racerId", Int32.Parse(Request.Form["driver" + i])}
                };

                var racerContent = JsonConvert.SerializeObject(newRacerInTeam);
                await _client.PostAsync("https://localhost:7232/api/Team/racer", new StringContent(racerContent, Encoding.UTF8, "application/json"));
            }

            for (int i = 1; i < 3; i++)
            {
                var newConstructorInTeam = new Dictionary<string, int>
                {
                    {"teamId", Int32.Parse(GetObject("https://localhost:7232/api/Team/name/" + name).Result["id"].ToString())},
                    {"constructorId", Int32.Parse(Request.Form["constructor" + i])}
                };

                var constructorContent = JsonConvert.SerializeObject(newConstructorInTeam);
                await _client.PostAsync("https://localhost:7232/api/Team/constructor", new StringContent(constructorContent, Encoding.UTF8, "application/json"));
            }

            return RedirectToPage("/Index");
        }
    }
}
