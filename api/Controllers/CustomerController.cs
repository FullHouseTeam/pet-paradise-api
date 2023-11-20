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

    [HttpGet(Name = "GetCustomers")]
    public async Task<IEnumerable<Customer>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}", Name = "GetCustomer")]
    public async Task<ActionResult<Customer>> GetById(int id)
    {
        var product = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if (product == null)
        {
          return ErrorUtilities.BrandNotFound(id);
        }
        return product;
    }

    [HttpPost(Name = "AddCustomer")]
    public async Task<IActionResult> Create(Customer customer)
    {
        var newCustomer = await _service.Create(customer);

        return CreatedAtAction(nameof(GetById), new { id = newCustomer.UserID }, customer);
    }

    [HttpPut("{id}", Name = "EditCustomer")]
    public async Task<IActionResult> Update(int id, Customer customer)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      if (id != customer.UserID)
      {
        return BadRequest(new { message = $"The ID({id}) URL doesn't match ID({customer.UserID}) of the request body."});
      }

      var customerToUpdate = await _service.GetByID(id);

      if (customerToUpdate is not null)
      {
        await _service.Update(id, customer);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }

    [HttpDelete("{id}", Name = "DeleteCustomer")]
     public async Task<IActionResult> Delete(int id)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var customerToDelete = await _service.GetByID(id);

      if (customerToDelete is not null)
      {
        await _service.Delete(id);
        return Ok();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }
    }
}
