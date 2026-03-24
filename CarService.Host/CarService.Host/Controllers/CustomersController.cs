using CarService.BL.Interfaces;
using CarService.Models.Dto;
using CarService.Models.Requests;
using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerCrudService _customerCrudService;
        private IValidator<AddCustomerRequest> _validator;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerCrudService customerCrudService, IValidator<AddCustomerRequest> validator, IMapper mapper)
        {
            _customerCrudService = customerCrudService;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerCrudService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPost(nameof(AddCustomer))]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest? customerRequest)
        {
            if (customerRequest == null)
            {
                return BadRequest("Customer data is null.");
            }

            var result = _validator.Validate(customerRequest);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var customer = _mapper.Map<Customer>(customerRequest);

            await _customerCrudService.AddCustomer(customer);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = _customerCrudService.GetById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            await _customerCrudService.DeleteCustomer(id);

            return Ok();
        }

        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _customerCrudService.GetById(id);

            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            return Ok(customer);
        }

        [HttpPost(nameof(UpdateCustomer))]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer? customer)
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
            await _customerCrudService.UpdateCustomer(customer);
            return Ok();
        }
    }
}
