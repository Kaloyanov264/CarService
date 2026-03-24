using CarService.BL.Interfaces;
using CarService.DL.Interfaces;
using CarService.Models.Dto;

namespace CarService.BL.Services
{
    internal class CarCrudService : ICarCrudService
    {
        private readonly ICarRepository _carRepository;

        public CarCrudService(ICarRepository carRepository)
        {
                _carRepository = carRepository;
        }

        public async Task AddCar(Car car)
        {
            if (car == null) return;

            if (car?.Id == null || car.Id == Guid.Empty)
            {
                car!.Id = Guid.NewGuid();
            }   

            await _carRepository.AddCar(car);
        }

        public async Task DeleteCar(Guid id)
        {
            await _carRepository.DeleteCar(id);
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _carRepository.GetAllCars();
        }

        public async Task<Car?> GetById(Guid id)
        {
            return await _carRepository.GetById(id);
        }

        public async Task UpdateCar(Car car)
        {
            await _carRepository.UpdateCar(car);
        }
    }
}
