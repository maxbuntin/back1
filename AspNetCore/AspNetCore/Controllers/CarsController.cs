using AspNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {

        private readonly CarsService cars;

        public CarsController(CarsService cars)
        {
            this.cars = cars;
        }

        [HttpGet("getCars")]
        public async Task<List<Cars>> GetCars()
        {
            var data = await cars.Get();
            return data;
        }

        [HttpGet("getCarsById")]
        public async Task<Cars> GetCarsById(string id)
        {
            var data = await cars.Get(id);
            return data;
        }

        [HttpPost("createCars")]
        public async Task<ActionResult> CreateCars([FromBody] Cars newCars)
        {
            await cars.Create(newCars);
            return Ok();
        }

        [HttpPut("updateCars")]
        public async Task UpdateCars(string id, Cars updateCars)
        {
            await cars.Update(id, updateCars);
        }

        [HttpDelete("deleteCars")]
        public async Task<ActionResult> DeleteCars(string id)
        {
            await cars.Remove(id);
            return Ok();
        }
    }
}
