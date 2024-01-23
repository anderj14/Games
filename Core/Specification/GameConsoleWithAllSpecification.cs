using Core.Entities;

namespace Core.Specification
{
    public class GameConsoleWithAllSpecification : BaseSpecification<GameConsole>
    {
        public GameConsoleWithAllSpecification(GameConsoleSpecParams gameConsoleParams)
            : base(x =>
                (string.IsNullOrEmpty(gameConsoleParams.Search) || x.ConsoleName.ToLower().Contains
                (gameConsoleParams.Search)) &&
                (!gameConsoleParams.BrandId.HasValue || x.BrandId == gameConsoleParams.BrandId) &&
                (!gameConsoleParams.CompanyId.HasValue || x.CompanyId == gameConsoleParams.CompanyId)
            )
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Company);
            AddInclude(x => x.TechnicalSpecification);
            AddOrderBy(x => x.ConsoleName);

            ApplyPaging(gameConsoleParams.PageIndex, gameConsoleParams.PageSize);

            if (!string.IsNullOrEmpty(gameConsoleParams.Sort))
            {
                switch (gameConsoleParams.Sort)
                {
                    case "releaseDateAsc":
                        AddOrderBy(gc => gc.ReleaseDate);
                        break;
                    case "releaseDateDesc":
                        AddOrderByDescending(gc => gc.ReleaseDate);
                        break;
                    default:
                        AddOrderBy(n => n.ConsoleName);
                        break;
                }
            }
        }

        public GameConsoleWithAllSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Company);
            AddInclude(x => x.TechnicalSpecification);
        }
    }
}