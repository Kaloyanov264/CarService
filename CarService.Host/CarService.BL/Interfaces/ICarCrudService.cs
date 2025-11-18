using CarService.Models.Dto;

namespace CarService.BL.Interfaces
{
    public interface ICarCrudService
    {
        void AddCar(Car car);

        void DeleteCar(int id);

        List<Car> GetAllCars();

        Car? GetById(int id);
    }
}
