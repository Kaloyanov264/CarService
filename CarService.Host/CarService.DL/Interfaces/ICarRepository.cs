using CarService.Models.Dto;

namespace CarService.DL.Interfaces
{
    public interface ICarRepository
    {
        void AddCar(Car car);

        void DeleteCar(int id);

        List<Car> GetAllCars();
    }
}
