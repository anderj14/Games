
using Core.Entities;

namespace Core.Specification.GameSpecification
{
    public class GameWithFilterAndCountSpecification : BaseSpecification<Game>
    {
        public GameWithFilterAndCountSpecification(GameSpecParams gameParams)
            : base(x =>
                (string.IsNullOrEmpty(gameParams.Search) || x.GameName.ToLower().Contains
                (gameParams.Search)) &&
                (!gameParams.GameConsoleId.HasValue || x.GameConsoleId == gameParams.GameConsoleId)
            )
        {
        }
    }
}