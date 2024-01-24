
using API.Dto;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification.GameSpecification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GamesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<GameDto>>> GetGames(
            [FromQuery] GameSpecParams gameParams
        )
        {
            var spec = new GameWithAllSpecification(gameParams);
            var countSpec = new GameWithFilterAndCountSpecification(gameParams);
            var totalItems = await _unitOfWork.Repository<Game>().CountAsync(countSpec);
            var games = await _unitOfWork.Repository<Game>().ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<GameDto>>(games);

            return Ok(new Pagination<GameDto>(gameParams.PageIndex, gameParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var spec = new GameWithAllSpecification(id);
            var game = await _unitOfWork.Repository<Game>().GetEntityWithSpec(spec);
            var data = _mapper.Map<GameDto>(game);
            return Ok(data);
        }
    }
}