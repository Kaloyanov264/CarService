using CarService.DL.Interfaces;
using CarService.DL.LocalDb;
using CarService.Models.Dto;

namespace CarService.DL.Repositories
{
    [Obsolete($"Please use: {nameof(CarMongoRepository)}")]
    internal class CarLocalRepository : ICarRepository
    {
        public void AddCar(Car car)
        {
            StaticDb.Cars.Add(car);
        }

        public void DeleteCar(Guid? id)
        {
            StaticDb.Cars.RemoveAll(c => c.Id == id);
        }

        public List<Car> GetAllCars()
        {
            return StaticDb.Cars;
        }

        public Car? GetById(Guid? id)
        {
            return StaticDb.Cars
                .FirstOrDefault(c => 
                c.Id == id);
        }

        public void UpdateCar(Car car)
        {
            var existingCar = GetById(car.Id);
            if (existingCar != null)
            {
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
            }
        }
    }
}
