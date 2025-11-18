using CarService.Models.Dto;

namespace CarService.DL.Interfaces
{
    internal interface ICustomerRepository
    {
        void AddCustomer(Customer customer);

        void DeleteCustomer(Guid id);

        Customer? GetById(Guid id);
    }
}
