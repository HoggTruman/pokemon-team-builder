using api.Interfaces.Repository;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;

        public PokemonController(IPokemonRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var pokemon = _repository.GetAllPokemon().Select(x => x.ToPokemonDTO());

            return Ok(pokemon);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var pokemon = _repository.GetPokemonById(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon.ToPokemonDTO());
        }
    }
}