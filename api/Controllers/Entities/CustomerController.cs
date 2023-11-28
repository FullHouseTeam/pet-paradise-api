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
        var product = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if (product == null)
        {
          return ErrorUtilities.FieldNotFound("Customer", id);
        }
        return product;
    }

    [HttpPost("save", Name = "AddCustomer")]
    public async Task<IActionResult> Create(CustomerDTO customerDTO)
    {
        var newCustomer = await _service.Create(customerDTO);
        if (newCustomer.Name.Equals("error_409_validations")) {
           return ErrorUtilities.UniqueName("Customer");
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
