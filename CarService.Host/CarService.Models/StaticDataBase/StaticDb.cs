using CarService.Models.Dto;

namespace CarService.Models.StaticDataBase
{
    public static class StaticDb
    {
        public static List<Car> Cars { get; set; } = new List<Car>
        {
            new Car { Id = Guid.NewGuid(), Model = "Toyota Camry", Year = 2020 },
            new Car { Id = Guid.NewGuid(), Model = "Honda Accord", Year = 2019 },
            new Car { Id = Guid.NewGuid(), Model = "Ford Mustang", Year = 2021 }
        };
    }
}
