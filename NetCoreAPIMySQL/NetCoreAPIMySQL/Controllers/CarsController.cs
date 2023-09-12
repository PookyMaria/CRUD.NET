using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepositorie _carsRepository;

        public CarsController(ICarsRepositorie carsRepository)
        {
            _carsRepository = carsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carsRepository.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarsDetails(int id)
        {
            return Ok(await _carsRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCars([FromBody] Cars cars) 
        {
            if (cars == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _carsRepository.InsertCars(cars);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCars([FromBody] Cars cars) 
        {
            if (cars == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _carsRepository.UpdateCars(cars);
            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCars(int id) 
        {
            await _carsRepository.DeleteCars(new Cars { Id = id });
            return NoContent();
        }

    }
}
