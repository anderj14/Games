
using API.Dto;
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
        public async Task<ActionResult<IReadOnlyList<GameConsoleDto>>> GetGameConsoles()
        {
            var spec = new GameConsoleWithAllSpecification();
            var gameConsoles = await _gameConsoleRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<GameConsoleDto>>(gameConsoles);
            return Ok(data);
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
