using F1FantasyAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1FantasyLibrary;
using F1FantasyLibrary.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace F1FantasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrandPrixController : ControllerBase
    {
        DataContext _context;
        public GrandPrixController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<GrandPrixModel>>> GetAllGrandPrix()
        {
            return await _context.GrandPrix.Include(x => x.CountryFlag).OrderByDescending(x => x.Date).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrandPrixModel>> GetGrandPrixById(int id)
        {
            return await _context.GrandPrix.Include(x => x.Results).ThenInclude(x => x.Racer).Include(x => x.CountryFlag).Where(x => x.Id == id).FirstAsync();
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<List<GrandPrixModel>>> GetGrandPrixForTeam(int teamId)
        {
            var teamResults = await _context.GrandPrixTeamResults.Where(x => x.TeamId == teamId).ToListAsync();
            var teamGrandPrix = new List<GrandPrixModel>();

            foreach (var res in teamResults)
            {
                teamGrandPrix.Add(await _context.GrandPrix.Where(x => x.Id == res.GrandPrixId).FirstAsync());
            }

            return teamGrandPrix;
        }

        [HttpPost]
        public async Task<ActionResult<GrandPrixModel>> AddGrandPrix(CreateGrandPrixDto request)
        {
            var grandPrix = new GrandPrixModel
            {
                Name = request.Name,
                Country = request.Country,
                Date = request.Date.Date
            };

            await _context.GrandPrix.AddAsync(grandPrix);
            await _context.SaveChangesAsync();

            int[] pointsToEarn = new int[] { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1 };

            for (int i = 0; i < request.Results.Count; i++)
            {
                var racer = await _context.Racers.FindAsync(request.Results[i]);

                if (racer == null)
                {
                    return NotFound();
                }
                var result = new GrandPrixResultsModel()
                {
                    GrandPrix = grandPrix,
                    Racer = racer,
                    Position = i + 1
                };

                if (i < 10)
                {
                    var points = pointsToEarn[i];
                    result.Points = points;
                }

                await _context.GrandPrixResults.AddAsync(result);
                await _context.SaveChangesAsync();
            }

            var teams = await _context.Teams.Include(x => x.Racers).Include(x => x.Constructors).ToListAsync();
            foreach (var team in teams)
            {
                int totalPoints = 0;

                foreach (var racer in team.Racers)
                {
                    var races = await _context.GrandPrixResults.Where(x => x.RacerId == racer.Id && x.GrandPrixId == grandPrix.Id).ToListAsync();
                    totalPoints += races.Sum(x => x.Points);
                }

                foreach (var constructor in team.Constructors)
                {
                    foreach (var racer in constructor.Racers)
                    {
                        var races = await _context.GrandPrixResults.Where(x => x.RacerId == racer.Id && x.GrandPrixId == grandPrix.Id).ToListAsync();
                        totalPoints += races.Sum(x => x.Points);
                    }
                }

                team.Points += totalPoints;

                var teamResult = new GrandPrixTeamResultModel()
                {
                    GrandPrix = grandPrix,
                    Team = team,
                    Points = totalPoints
                };

                await _context.GrandPrixTeamResults.AddAsync(teamResult);
                await _context.SaveChangesAsync();
            }

            return grandPrix;
        }
    }
}
