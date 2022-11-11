using Microsoft.AspNetCore.Mvc;
using ODataProject_CustomersData.Model;
using ODataProject_CustomersData.Repository;

namespace ODataProject_CustomersData.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository ICustomerRepository;

        public CustomerController(ICustomerRepository _iCustomerRepository)
        {
            ICustomerRepository = _iCustomerRepository;
        }
  

        [HttpGet("customers/all")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var allcustomers = await   ICustomerRepository.GetCustomerData();
            return Ok(allcustomers);
           
        }

        [HttpGet("customers/{id:int}")]
        public async Task<IActionResult> GetCustomerByID([FromRoute] int id)
        {
            var allcustomers = await ICustomerRepository.GetCustomerById(id);
            if (allcustomers == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(allcustomers);
            }
        }

        [HttpPost("customers/new")]
        public async Task<IActionResult> AddNewCustomer([FromBody] CustomerModel customer)
        {
            var allcustomers = await ICustomerRepository.PostNewCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerByID), new { id = customer.CustomerId, Controller = "Customer" }, customer);
        }


        [HttpDelete("customers/delete/{id:int}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await ICustomerRepository.DeleteCustomer(id);
            return Ok();
        }

        [HttpPut("customers/update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerModel customer)
        {
            await ICustomerRepository.UpdateCustomer(customer);
            return Ok();
        }


    }


}
