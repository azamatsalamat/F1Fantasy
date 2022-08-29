using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1FantasyLibrary;
using F1FantasyLibrary.DataTransferObjects;
using F1FantasyAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace F1FantasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructorController : ControllerBase
    {
        DataContext _context;
        public ConstructorController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ConstructorModel>> CreateConstructor(CreateConstructorDto request)
        {
            ConstructorModel constructor = new ConstructorModel
            {
                Name = request.Name
            };

            await _context.Constructors.AddAsync(constructor);
            await _context.SaveChangesAsync();

            return constructor;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConstructorModel>>> GetConstructors()
        {
            return await _context.Constructors.Include(x => x.Racers).Include(x => x.Logo).ToListAsync();
        }
    }
}
