
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
        private readonly IUnitOfWork _unitOfWork;
        public GameConsolesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<GameConsoleDto>>> GetGameConsoles(
            [FromQuery] GameConsoleSpecParams gameConsoleParams
        )
        {
            var spec = new GameConsoleWithAllSpecification(gameConsoleParams);

            var countSpec = new GameConsoleWithCountSpecification(gameConsoleParams);

            var totalItems = await _unitOfWork.Repository<GameConsole>().CountAsync(countSpec);

            var gameConsoles = await _unitOfWork.Repository<GameConsole>().ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<GameConsoleDto>>(gameConsoles);

            return Ok(
                new Pagination<GameConsoleDto>(gameConsoleParams.PageIndex, gameConsoleParams.PageSize, totalItems, data)
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameConsoleDto>> GetGameConsole(int id)
        {
            var spec = new GameConsoleWithAllSpecification(id);
            var gameConsole = await _unitOfWork.Repository<GameConsole>().GetEntityWithSpec(spec);
            var data = _mapper.Map<GameConsoleDto>(gameConsole);
            return Ok(data);
        }
    }
}
