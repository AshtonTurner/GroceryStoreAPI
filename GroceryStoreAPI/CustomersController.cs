using GroceryStoreAPI.Entities;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomer _customerservice;
        public CustomersController(ICustomer customerService)
        {

            _customerservice = customerService;
        }


        // GET api/customers
        [HttpGet]
        public string Get()
        {

            return "API is live.";
        }

        [HttpGet("getcustomers/")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var items = _customerservice.GetAllCustomers();
            return Ok(items);
        }

        // GET api/customers/customerid
        [HttpGet("getcustomer/{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
          var customer=  _customerservice.GetById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers/addcustomer
        [HttpPost("addcustomer/")]
        public ActionResult<Customer> AddCustomers([FromBody] Customer C)
        {
            var item = _customerservice.Add(C);
            if(item!=null)
              return Ok(item);

            return BadRequest();
        }

        // PUT api/customers/updatecustomer
        [HttpPut("updatecustomer/")]
        public ActionResult<Customer> Put([FromBody] Customer C)
        {
                var item =_customerservice.Update(C);
                if (item != null)
                    return Ok(item);

                return BadRequest();
        }

  
    }
}
