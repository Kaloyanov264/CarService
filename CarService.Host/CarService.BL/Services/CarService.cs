using CarService.BL.Interfaces;
using CarService.DL.Interfaces;
using CarService.Models.Dto;

namespace CarService.BL.Services
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
                _carRepository = carRepository;
        }

        public void AddCar(Car car)
        {
            _carRepository.AddCar(car);
        }

        public void DeleteCar(int id)
        {
            _carRepository.DeleteCar(id);
        }

        public List<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }
    }
}
