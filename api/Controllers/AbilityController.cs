using api.Interfaces.Repository;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/ability")]
    [ApiController]
    public class AbilityController : ControllerBase
    {
        private readonly IAbilityRepository _repository;

        public AbilityController(IAbilityRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var abilities = _repository.GetAll().Select(x => x.ToAbilityDTO());

            return Ok(abilities);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var ability = _repository.GetById(id);

            if (ability == null)
                return NotFound();

            return Ok(ability.ToAbilityDTO());
        }
    }
}