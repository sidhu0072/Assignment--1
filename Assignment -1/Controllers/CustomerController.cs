using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("GetCustomerById/{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NoContent();
            }

            return customer;
        }
    }
}
