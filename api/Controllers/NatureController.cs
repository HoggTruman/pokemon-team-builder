using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/nature")]
    [ApiController]
    public class NatureController : ControllerBase
    {
        private readonly INatureRepository _repository;

        public NatureController(INatureRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var natures = _repository.GetAll().Select(x => x.ToNatureDTO());

            return Ok(natures);
        }
    }
}