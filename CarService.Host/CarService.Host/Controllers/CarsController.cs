using CarService.BL.Interfaces;
using CarService.Models.Dto;
using CarService.Models.Requests;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarCrudService _carCrudService;
        private readonly IMapper _mapper;

        public CarsController(
            ICarCrudService carCrudService, 
            IMapper mapper)
        {
            _carCrudService = carCrudService;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var cars = _carCrudService.GetAllCars();
            return Ok(cars);
        }

        [HttpPost(nameof(AddCar))]
        public IActionResult AddCar([FromBody] AddCarRequest? carRequest)
        {
            if (carRequest == null)
            {
                return BadRequest("Car data is null.");
            }

            var car = _mapper.Map<Car>(carRequest);

            _carCrudService.AddCar(car);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCar(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id must be a valid Guid.");
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
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id must be a valid Guid.");
            }

            var car = _carCrudService.GetById(id);
           
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }
            return Ok(car);
        }

        [HttpPost(nameof(UpdateCar))]
        public IActionResult UpdateCar([FromBody] Car? car)
        {
            if (car == null)
            {
                return BadRequest("Car data is null.");
            }
            var existingCar = _carCrudService.GetById(car.Id);
            if (existingCar == null)
            {
                return NotFound($"Car with ID {car.Id} not found.");
            }
            _carCrudService.UpdateCar(car);
            return Ok();
        }
    }
}
