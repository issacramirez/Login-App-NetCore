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
    public class EmployeesController : ControllerBase {

        private EmployeesService employeesService = new EmployeesService();

        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get() {
            var employees = employeesService.GetAllEmployees().Select(s => new Employees {
                EmployeeId = s.EmployeeId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                Address = s.Address
            }).ToList();
            return Ok(employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                var employee = employeesService.GetEmployeeById(id);
                return Ok(employee);
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel newEmployee) {
            try {
                employeesService.AddEmployee(newEmployee);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] string newNameEmployee) {
            try {
                employeesService.UpdateNameEmployeeById(id,newNameEmployee);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                employeesService.DeleteEmployeeById(id);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        #region helpers

        private IActionResult ThrowInternalServerError(Exception e) {
            return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
        }

        #endregion


    }
}
