using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1FantasyAPI.Data;
using F1FantasyLibrary;
using F1FantasyLibrary.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace F1FantasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        DataContext _context;
        public TeamController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamModel>>> GetTeams()
        {
            var teams = await _context.Teams.Include(x => x.Racers).ThenInclude(x => x.Image)
                .Include(x => x.Constructors).ThenInclude(x => x.Logo).OrderByDescending(x => x.Points).ToListAsync();

            foreach (var t in teams)
            {
                t.CurrentCost = t.Racers.Sum(x => x.Price) + t.Constructors.Sum(x => x.Price);
            };
            await _context.SaveChangesAsync();

            return teams;
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<TeamModel>> GetTeamByName(string name)
        {
            var team = await _context.Teams.Where(x => x.Name == name).FirstAsync();
            if (team == null) { return NotFound(); }

            return team;
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<TeamModel>> GetTeamById(int id)
        {
            var team = await _context.Teams.Where(x => x.Id == id).Include(x => x.Racers).ThenInclude(x => x.Image)
                .Include(x => x.Constructors).ThenInclude(x => x.Logo).Include(x => x.Results).FirstAsync();
            if (team == null) { return NotFound(); }

            return team;
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> CreateTeam(CreateTeamDto request)
        {
            var team = new TeamModel 
            { 
                Name = request.Name,
                Cost = request.Cost,
            };

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return team;
        }

        [HttpPost("racer")]
        public async Task<ActionResult<TeamModel>> AddRacerToTeam(AddRacerToTeamDto request)
        {
            var team = await _context.Teams.FindAsync(request.TeamId);
            if (team == null) { return NotFound(); }

            var racer = await _context.Racers.FindAsync(request.RacerId);
            if (racer == null) { return NotFound(); }

            team.Racers.Add(racer);
            racer.Teams.Add(team);

            await _context.SaveChangesAsync();

            return team;
        }

        [HttpPost("constructor")]
        public async Task<ActionResult<TeamModel>> AddConstructorToTeam(AddConstructorToTeamDto request)
        {
            var team = await _context.Teams.FindAsync(request.TeamId);
            if (team == null) { return NotFound(); }

            var constructor = await _context.Constructors.FindAsync(request.ConstructorId);
            if (constructor == null) { return NotFound(); }

            team.Constructors.Add(constructor);
            constructor.Teams.Add(team);

            await _context.SaveChangesAsync();

            return team;
        }
    }
}
