using Login_App_NetCore.DataAccess;
using Login_App_NetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_App_NetCore.Services {
    public class CustomersService : ContextService {

        public IQueryable<Customers> GetAllCustomers() {
            return dataContext.Customers.Select(s => s);
        }

        public Customers GetCustomerById(string id) {
            var customer = GetAllCustomers().Where(w => w.CustomerId == id).FirstOrDefault();
            if(customer == null)
                throw new Exception("El id del cliente ingresado no existe");
            return customer;
        }

        public void UpdateContactNameById(string id, string newName) {
            Customers customer = GetCustomerById(id);
            customer.ContactName = newName;
            dataContext.SaveChanges();
        }

        public void DeleteCustomerById(string id) {
            Customers customer = GetCustomerById(id);
            dataContext.Customers.Remove(customer);
            dataContext.SaveChanges();
        }

        public void CreateNewCustomer(CustomersModel Customer) {
            var newCustomer = new Customers() {
                CustomerId = Customer.ClienteId,
                CompanyName = Customer.NombreCompañía,
                ContactName = Customer.NombreContacto,
                ContactTitle = Customer.TituloContacto
            };

            dataContext.Customers.Add(newCustomer);
            dataContext.SaveChanges();
        }
    }
}
