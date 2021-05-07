using Login_App_NetCore.DataAccess;
using Login_App_NetCore.Model;
using Login_App_NetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login_App_NetCore.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase {

        private CustomersService customersService = new CustomersService();

        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult Get() {
            var customers = customersService.GetAllCustomers().Select(s => new Customers {
                CustomerId = s.CustomerId,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle
            }).ToList();
            return Ok(customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id) {
            try {
                var customer = customersService.GetCustomerById(id);
                return Ok(customer);
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomersModel newCustomer) {
            try {
                customersService.CreateNewCustomer(newCustomer);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id,[FromBody] string newName) {
            try {
                customersService.UpdateContactNameById(id,newName);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id) {
            try {
                customersService.DeleteCustomerById(id);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        #region

        private IActionResult ThrowInternalServerError(Exception e) {
            return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
        }

        #endregion

    }
}
