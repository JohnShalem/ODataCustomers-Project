using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataProject_CustomersData.Repository;

namespace ODataProject_CustomersData.Controllers
{
    [Route("api/odata/")]
    [ApiController]
    public class ODataCustomers : ControllerBase
    {

        private readonly ICustomerRepository ICustomerRepository;

        public ODataCustomers(ICustomerRepository _iCustomerRepository)
        {
            ICustomerRepository = _iCustomerRepository;
        }


        [HttpGet("all")]
        [EnableQuery]
        public async Task<IActionResult> GetAllCustomer()
        {
            var allcustomers = await ICustomerRepository.GetCustomerData();
            return Ok(allcustomers);

        }
    }
}
