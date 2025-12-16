using CarService.BL.Services;
using CarService.DL.Interfaces;
using CarService.Models.Dto;
using CarService.Tests.MockData;
using Moq;

namespace CarService.Tests.CustomerTests
{
    public class CustomerCrudServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;

        public CustomerCrudServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void AddCustomerTest_Ok()
        {
            //setup
            var expectedCustomerCount = CustomerMockedData.Customers.Count + 1;
            var id = Guid.NewGuid();
            var customer = new Customer
            {
                Id = id,
                Name = "John Doe",
                Email = "jd@xxx.com"
            };

            Customer resultCustomer = null;
            _customerRepositoryMock
                .Setup(repo => repo.AddCustomer(customer))
                .Callback(() =>
                {
                    CustomerMockedData.Customers.Add(customer);
                });

            //inject
            var service = new CustomerCrudService(_customerRepositoryMock.Object);

            //act
            service.AddCustomer(customer);

            resultCustomer = CustomerMockedData.Customers.FirstOrDefault(c => c.Id == id);
            //assert
            Assert.NotNull(resultCustomer);
            Assert.Contains(customer, CustomerMockedData.Customers);
            Assert.Equal(expectedCustomerCount, CustomerMockedData.Customers.Count);
            Assert.Equal(id, resultCustomer.Id);
        }
    }
}
