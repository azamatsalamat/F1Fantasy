using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1FantasyAPI.Data;
using F1FantasyLibrary;
using F1FantasyLibrary.FileModels;
using F1FantasyLibrary.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace F1FantasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacerController : ControllerBase
    {
        DataContext _context;

        public RacerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RacerModel>>> GetRacers()
        {
            return await _context.Racers.Include(x => x.Image).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RacerModel>> GetRacerById(int id)
        {
            var racer = await _context.Racers.Include(x => x.Image).Where(x => x.Id == id).FirstAsync();
            if (racer == null) { return NotFound(); }

            return racer;
        }

        [HttpPost]
        public async Task<ActionResult<RacerModel>> CreateRacer(CreateRacerDto request)
        {
            var constructor = await _context.Constructors.FindAsync(request.ConstructorId);
            if (constructor == null) { return NotFound(); }

            var racer = new RacerModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ConstructorId = request.ConstructorId,
                Constructor = constructor
            };

            await _context.Racers.AddAsync(racer);
            await _context.SaveChangesAsync();

            return racer;
        }
    }
}
