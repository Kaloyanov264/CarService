using CarService.BL.Interfaces;
using CarService.DL.Interfaces;
using CarService.Models.Dto;
using Moq;

namespace CarService.Tests.CarTests
{
    public class SellCarTests
    {
        Mock<ICarCrudService> _carCrudServiceMock;
        Mock<ICustomerRepository> _customerRepositoryMock;

        [Fact]
        public async Task Sell_Return_Ok()
        {
            _carCrudServiceMock = new Mock<ICarCrudService>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            var expectedPrice = 79000m;

            _carCrudServiceMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new Models.Dto.Car
                {
                    Id = Guid.NewGuid(),
                    Model = "Model S",
                    Year = 2022,
                    BasePrice = 80000m
                });

            _customerRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new Models.Dto.Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice Johnson",
                    Email = "aj@gmail.com",
                    Discount = 1000
                });

            var sellService = new BL.Services.SellCar(_carCrudServiceMock.Object, _customerRepositoryMock.Object);

            //act
            var result = await sellService.Sell(Guid.NewGuid(), Guid.NewGuid());

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedPrice, result.Price); 
        }

        [Fact]
        public async Task Sell_When_Customer_Missing()
        {
            _carCrudServiceMock = new Mock<ICarCrudService>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            var expectedPrice = 79000m;

            _carCrudServiceMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(new Models.Dto.Car
                {
                    Id = Guid.NewGuid(),
                    Model = "Model S",
                    Year = 2022,
                    BasePrice = 80000m
                });

            _customerRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((Customer)null);

            var sellService = new BL.Services.SellCar(_carCrudServiceMock.Object, _customerRepositoryMock.Object);

            //act + assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => sellService.Sell(Guid.NewGuid(), Guid.NewGuid()));
            //var result = sellService.Sell(Guid.NewGuid(), Guid.NewGuid());

            //assert
            //Assert.NotNull(result);
            //Assert.Equal(expectedPrice, result.Price);
        }

    }
}
