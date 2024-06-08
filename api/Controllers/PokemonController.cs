using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PokemonController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var pokemon = _context.Pokemon
                .Include(x => x.PkmnTypes)
                .Include(x => x.BaseStats)
                .Include(x => x.Abilities)
                .ToList()
                .Select(x => x.ToPokemonDTO());

            return Ok(pokemon);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var pokemon = _context.Pokemon
                .Include(x => x.PkmnTypes)
                .Include(x => x.BaseStats)
                .Include(x => x.Abilities)
                .FirstOrDefault(x => x.Id == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon.ToPokemonDTO());
        }
    }
}