
using Core.Entities;

namespace Core.Specification.GameSpecification
{
    public class GameWithAllSpecification : BaseSpecification<Game>
    {
        public GameWithAllSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.GameConsole);
        }

        public GameWithAllSpecification(GameSpecParams gameParams)
            : base(x =>
                (string.IsNullOrEmpty(gameParams.Search) || x.GameName.ToLower().Contains
                (gameParams.Search)) &&
                (!gameParams.GameConsoleId.HasValue || x.GameConsoleId == gameParams.GameConsoleId)
            )
        {
            AddInclude(x => x.GameConsole);
            AddOrderBy(x => x.GameName);

            ApplyPaging(gameParams.PageIndex, gameParams.PageSize);

            if (!string.IsNullOrEmpty(gameParams.Sort))
            {
                switch (gameParams.Sort)
                {
                    case "releaseDateAsc":
                        AddOrderBy(g => g.ReleaseDate);
                        break;
                    case "releaseDateDesc":
                        AddOrderByDescending(g => g.ReleaseDate);
                        break;
                    default:
                        AddOrderBy(n => n.GameName);
                        break;
                }
            }
        }
    }
}