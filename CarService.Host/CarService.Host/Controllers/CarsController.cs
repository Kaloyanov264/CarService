using CarService.BL.Interfaces;
using CarService.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarCrudService _carCrudService;

        public CarsController(ICarCrudService carService)
        {
            _carCrudService = carService;
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var cars = _carCrudService.GetAllCars();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] Car? car)
        {
            if (car == null)
            {
                return BadRequest("Car data is null.");
            }

            _carCrudService.AddCar(car);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0.");
            }

            var car = _carCrudService.GetById(id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");    
            }

            _carCrudService.DeleteCar(id);

            return Ok();
        }

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0.");
            }

            var car = _carCrudService.GetById(id);
           
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }
            return Ok(car);
        }
    }
}
