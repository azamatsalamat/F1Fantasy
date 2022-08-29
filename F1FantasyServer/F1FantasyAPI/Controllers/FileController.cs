using F1FantasyAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1FantasyLibrary;
using F1FantasyLibrary.FileModels;

namespace F1FantasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        DataContext _context;

        public FileController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("constructor")]
        public async Task<ActionResult<ConstructorFileModel>> UploadConstructorFile(IFormFile file, int constructorId)
        {
            var constructor = await _context.Constructors.FindAsync(constructorId);
            if (constructor == null) { return NotFound(); }

            var storageName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var constructorFile = new ConstructorFileModel
            {
                FileName = file.FileName,
                StorageName = storageName,
                Url = @"https://localhost:7232/" + storageName,
                ConstructorId = constructorId,
                Constructor = constructor
            };

            FileProcessor.SaveFile(file, storageName);

            await _context.ConstructorLogos.AddAsync(constructorFile);
            await _context.SaveChangesAsync();

            return constructorFile;
        }

        [HttpPost("racer")]
        public async Task<ActionResult<RacerFileModel>> UploadRacerFile(IFormFile file, int racerId)
        {
            var racer = await _context.Racers.FindAsync(racerId);
            if (racer == null) { return NotFound(); }

            var storageName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var racerFile = new RacerFileModel
            {
                FileName = file.FileName,
                StorageName = storageName,
                Url = @"https://localhost:7232/" + storageName,
                RacerId = racerId,
                Racer = racer
            };

            FileProcessor.SaveFile(file, storageName);

            await _context.RacerImages.AddAsync(racerFile);
            await _context.SaveChangesAsync();

            return racerFile;
        }

        [HttpPost("grandPrix")]
        public async Task<ActionResult<GrandPrixFileModel>> UploadGrandPrixFile(IFormFile file, int grandPrixId)
        {
            var grandPrix = await _context.GrandPrix.FindAsync(grandPrixId);
            if (grandPrix == null) { return NotFound(); }

            var storageName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var grandPrixFile = new GrandPrixFileModel
            {
                FileName = file.FileName,
                StorageName = storageName,
                Url = @"https://localhost:7232/" + storageName,
                GrandPrixId = grandPrixId,
                GrandPrix = grandPrix
            };

            FileProcessor.SaveFile(file, storageName);

            await _context.GrandPrixFlags.AddAsync(grandPrixFile);
            await _context.SaveChangesAsync();

            return grandPrixFile;
        }
    }
}
