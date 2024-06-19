using api.Data;
using api.Interfaces.Repository;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/move")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly IMoveRepository _repository;

        public MoveController(IMoveRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var moves = _repository.GetAll().Select(x => x.ToMoveDTO());

            return Ok(moves);
        }

        [HttpGet("{pokemonId:int}")]
        public IActionResult GetMovesByPokemonId([FromRoute] int pokemonId)
        {
            var moves = _repository.GetMovesByPokemonId(pokemonId);

            if (moves == null)
            {
                return NotFound();
            }

            return Ok(moves.Select(x => x.ToMoveDTO()));
        }
    }
}