using CarService.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.BL.Interfaces
{
    public interface ICustomerCrudService
    {
        void AddCustomer(Customer customer);

        void DeleteCustomer(Guid id);

        Customer? GetById(Guid id);
    }
}
