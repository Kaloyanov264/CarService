using CarService.BL.Interfaces;
using CarService.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerCrudService _customerCrudService;

        public CustomersController(ICustomerCrudService customerCrudService)
        {
            _customerCrudService = customerCrudService;
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var customers = _customerCrudService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPost(nameof(AddCustomer))]
        public IActionResult AddCustomer([FromBody] Customer? customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }

            _customerCrudService.AddCustomer(customer);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(Guid id)
        {
            var customer = _customerCrudService.GetById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            _customerCrudService.DeleteCustomer(id);

            return Ok();
        }

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(Guid id)
        {
            var customer = _customerCrudService.GetById(id);

            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            return Ok(customer);
        }

        [HttpPost(nameof(UpdateCustomer))]
        public IActionResult UpdateCustomer([FromBody] Customer? customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }
            var existingCustomer = _customerCrudService.GetById(customer.Id);
            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {customer.Id} not found.");
            }
            _customerCrudService.UpdateCustomer(customer);
            return Ok();
        }
    }
}
