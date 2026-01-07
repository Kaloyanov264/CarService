using CarService.BL.Services;
using CarService.DL.Interfaces;
using CarService.Models.Dto;
using CarService.Tests.MockData;
using Moq;

namespace CarService.Tests.CarTests
{
    public class CarCrudServiceTests
    {
        private readonly Mock<ICarRepository> _carRepositoryMock;

        public CarCrudServiceTests()
        {
            _carRepositoryMock = new Mock<ICarRepository>();

        }

        [Fact]
        public void AddCarTest_Ok()
        {
            //setup
            var expectedCarCount = CarMockedData.Cars.Count + 1;
            var id = Guid.NewGuid();
            var car = new Car
            {
                Id = id,
                Model = "Camry",
                Year = 2020
            };

            Car resultCar = null;
            _carRepositoryMock
                .Setup(repo => repo.AddCar(car))
                .Callback( () =>
                {                    
                    CarMockedData.Cars.Add(car);
                });

            //inject
            var service = new CarCrudService(_carRepositoryMock.Object);

            //act
            service.AddCar(car);

            resultCar = CarMockedData.Cars.FirstOrDefault(c => c.Id == id);
            //assert
            Assert.NotNull(resultCar);
            Assert.Contains(car, CarMockedData.Cars);
            Assert.Equal(expectedCarCount, CarMockedData.Cars.Count);
            Assert.Equal(id, resultCar.Id);
        }

        [Fact]
        public void DeleteCarTest_Ok()
        {
            // setup
            var carToDelete = CarMockedData.Cars.First();
            var initialCarCount = CarMockedData.Cars.Count;

            _carRepositoryMock
                .Setup(repo => repo.DeleteCar(carToDelete.Id))
                .Callback(() =>
                {
                    var car = CarMockedData.Cars.FirstOrDefault(c => c.Id == carToDelete.Id);
                    if (car != null)
                    {
                        CarMockedData.Cars.Remove(car);
                    }
                });

            // inject
            var service = new CarCrudService(_carRepositoryMock.Object);

            // act
            service.DeleteCar(carToDelete.Id);

            var deletedCar = CarMockedData.Cars.FirstOrDefault(c => c.Id == carToDelete.Id);

            // assert
            Assert.Null(deletedCar);
            Assert.Equal(initialCarCount - 1, CarMockedData.Cars.Count);
        }

        [Fact]
        public void UpdateCarTest_Ok()
        {
            // setup
            var existingCar = CarMockedData.Cars.First();
            var updatedModel = "Corolla";
            var updatedYear = 2022;
            var expectedCarCount = CarMockedData.Cars.Count;

            var updatedCar = new Car
            {
                Id = existingCar.Id,
                Model = updatedModel,
                Year = updatedYear
            };

            _carRepositoryMock
                .Setup(repo => repo.UpdateCar(updatedCar))
                .Callback(() =>
                {
                    var car = CarMockedData.Cars
                        .FirstOrDefault(c => c.Id == updatedCar.Id);

                    if (car != null)
                    {
                        car.Model = updatedCar.Model;
                        car.Year = updatedCar.Year;
                    }
                });

            // inject
            var service = new CarCrudService(_carRepositoryMock.Object);

            // act
            service.UpdateCar(updatedCar);

            var resultCar = CarMockedData.Cars
                .FirstOrDefault(c => c.Id == updatedCar.Id);

            // assert
            Assert.NotNull(resultCar);
            Assert.Equal(updatedModel, resultCar.Model);
            Assert.Equal(updatedYear, resultCar.Year);
            Assert.Equal(expectedCarCount, CarMockedData.Cars.Count);
        }
    }
}
