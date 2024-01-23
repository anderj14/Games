using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class GameConsoleWithAllSpecification : BaseSpecification<GameConsole>
    {
        public GameConsoleWithAllSpecification()
        {
            AddInclude(x => x.TechnicalSpecification);
            AddInclude(x => x.Brand);
            AddInclude(x => x.Company);
        }

        public GameConsoleWithAllSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.TechnicalSpecification);
            AddInclude(x => x.Brand);
            AddInclude(x => x.Company);
        }
    }
}