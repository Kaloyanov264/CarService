using CarService.Models.Dto;

namespace CarService.DL.LocalDb
{
    internal static class StaticDb
    {
        public static List<Car> Cars = new List<Car>
        {
            new Car { Id = 1, Model = "Toyota Camry", Year = 2020 },
            new Car { Id = 2, Model = "Honda Accord", Year = 2019 },
            new Car { Id = 3, Model = "Ford Mustang", Year = 2021 },
        };
    }
}
