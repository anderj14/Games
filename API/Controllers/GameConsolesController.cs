
using API.Dto;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GameConsolesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<GameConsole> _gameConsoleRepo;
        public GameConsolesController(IGenericRepository<GameConsole> gameConsoleRepo, IMapper mapper)
        {
            _gameConsoleRepo = gameConsoleRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<GameConsoleDto>>> GetGameConsoles(
            [FromQuery] GameConsoleSpecParams gameConsoleParams
        )
        {
            var spec = new GameConsoleWithAllSpecification(gameConsoleParams);

            var countSpec = new GameConsoleWithCountSpecification(gameConsoleParams);
            
            var totalItems = await _gameConsoleRepo.CountAsync(countSpec);

            var gameConsoles = await _gameConsoleRepo.ListAsync(spec);
            
            var data = _mapper.Map<IReadOnlyList<GameConsoleDto>>(gameConsoles);

            return Ok(
                new Pagination<GameConsoleDto>(gameConsoleParams.PageIndex, gameConsoleParams.PageSize, totalItems, data)
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameConsoleDto>> GetGameConsole(int id)
        {
            var spec = new GameConsoleWithAllSpecification(id);
            var gameConsole = await _gameConsoleRepo.GetEntityWithSpec(spec);
            var data = _mapper.Map<GameConsoleDto>(gameConsole);
            return Ok(data);
        }
    }
}
