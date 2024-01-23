
using Core.Entities;

namespace Core.Specification
{
    public class GameConsoleWithCountSpecification : BaseSpecification<GameConsole>
    {
        public GameConsoleWithCountSpecification(GameConsoleSpecParams gameConsoleParams)
            : base(x =>
                (string.IsNullOrEmpty(gameConsoleParams.Search) || x.ConsoleName.ToLower()
                .Contains(gameConsoleParams.Search)) &&
                (!gameConsoleParams.BrandId.HasValue || x.BrandId == gameConsoleParams.BrandId) &&
                (!gameConsoleParams.CompanyId.HasValue || x.CompanyId == gameConsoleParams.CompanyId)
            )
        {
        }
    }
}