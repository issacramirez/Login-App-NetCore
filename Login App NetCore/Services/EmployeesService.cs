using Login_App_NetCore.DataAccess;
using Login_App_NetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_App_NetCore.Services {
    public class EmployeesService : ContextService {

        public IQueryable<Employees> GetAllEmployees() {
            return dataContext.Employees.Select(s => s);
        }

        public Employees GetEmployeeById(int id) {
            var employee = GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
            if(employee == null)
                throw new Exception("El id del empleado ingresado no existe.");
            return employee;
        }

        public void UpdateNameEmployeeById(int id, string newName) {
            Employees employee = GetEmployeeById(id);
            employee.FirstName = newName;
            dataContext.SaveChanges();
        }

        public void DeleteEmployeeById(int id) {
            Employees employee = GetEmployeeById(id);
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        public void AddEmployee(EmployeeModel employee) {
            var newEmployee = new Employees() {
                FirstName = employee.Nombre,
                LastName = employee.SegundoNombre
            };

            dataContext.Employees.Add(newEmployee);
            dataContext.SaveChanges();
        }

    }
}
