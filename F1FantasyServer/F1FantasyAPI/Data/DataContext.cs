using Microsoft.EntityFrameworkCore;
using F1FantasyLibrary;
using F1FantasyLibrary.FileModels;

namespace F1FantasyAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RacerModel> Racers { get; set; }
        public DbSet<ConstructorModel> Constructors { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<GrandPrixModel> GrandPrix { get; set; }
        public DbSet<GrandPrixResultsModel> GrandPrixResults { get; set; }
        public DbSet<GrandPrixTeamResultModel> GrandPrixTeamResults { get; set; }
        public DbSet<RacerFileModel> RacerImages { get; set; }
        public DbSet<ConstructorFileModel> ConstructorLogos { get; set; }
        public DbSet<GrandPrixFileModel> GrandPrixFlags { get; set; }

    }
}
