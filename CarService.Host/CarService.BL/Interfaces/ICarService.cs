using CarService.Models.Dto;

namespace CarService.BL.Interfaces
{
    public interface ICarService
    {
        void AddCar(Car car);

        void DeleteCar(int id);

        List<Car> GetAllCars();
    }
}
