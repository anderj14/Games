using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class GamesRoomContextSeed
    {
        public static async Task SeedAsync(GamesRoomContext context)
        {
            if (!context.GameConsoles.Any())
            {
                var gamesConsoleData = File.ReadAllText("../Infrastructure/Data/SeedData/gameconsole.json");
                var gamesconsole = JsonSerializer.Deserialize<List<GameConsole>>(gamesConsoleData);
                context.GameConsoles.AddRange(gamesconsole);
            }
            if (!context.Brands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brand.json");
                var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
                context.Brands.AddRange(brands);
            }
            if (!context.Companies.Any())
            {
                var companiesData = File.ReadAllText("../Infrastructure/Data/SeedData/company.json");
                var companies = JsonSerializer.Deserialize<List<Company>>(companiesData);
                context.Companies.AddRange(companies);
            }
            if (!context.Games.Any())
            {
                var gamesData = File.ReadAllText("../Infrastructure/Data/SeedData/game.json");
                var games = JsonSerializer.Deserialize<List<Game>>(gamesData);
                context.Games.AddRange(games);
            }
            if (!context.TechnicalSpecifications.Any())
            {
                var technicalSpecificationsData = File.ReadAllText("../Infrastructure/Data/SeedData/technicalspecification.json");
                var technicalSpecifications = JsonSerializer.Deserialize<List<TechnicalSpecification>>(technicalSpecificationsData);
                context.TechnicalSpecifications.AddRange(technicalSpecifications);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}