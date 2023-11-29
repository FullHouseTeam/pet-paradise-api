using api.DTOs;
using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
    {
        _service = service;
    }

    [HttpGet("list", Name = "GetCustomers")]
    public async Task<IEnumerable<Customer>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("list/id", Name = "GetCustomer")]
    public async Task<ActionResult<Customer>> GetById(int id)
    {
        var customer = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if (customer == null)
        {
          return ErrorUtilities.FieldNotFound("Customer", id);
        }
        return customer;
    }

    [HttpPost("save", Name = "AddCustomer")]
    public async Task<IActionResult> Create(CustomerDTO customerDTO)
    {
        var newCustomer = await _service.Create(customerDTO);
        if (newCustomer.Name.Equals("name_error_409_validations")) {
           return ErrorUtilities.UniqueName("Customer");
        }

        if (newCustomer.Email.Equals("email_error_409_validations")) {
           return ErrorUtilities.EmailName("Email");
        }

        return CreatedAtAction(nameof(GetById), new { id = newCustomer.CustomerID }, customerDTO);
    }

    [HttpPut("edit", Name = "EditCustomer")]
    public async Task<IActionResult> Update(int id, CustomerDTO customerDTO)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var customerToUpdate = await _service.GetByID(id);

      if (customerToUpdate is not null)
      {
        await _service.Update(id, customerDTO);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.FieldNotFound("Customer", id);
      }
    }
  }
}
