using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Customer> GetAllCustomers
        {
            get
            {
                return _appDbContext.Customers;
            }
        }

        public void AddCustomer(Customer customer)
        {
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChangesAsync();
        }

        public void Delete(Customer customer)
        {
            _appDbContext.Customers.Remove(customer);
            _appDbContext.SaveChangesAsync();
        }

        public void Edit(Customer customer)
        {
           _appDbContext.Customers.Update(customer);
           _appDbContext.SaveChangesAsync();

        }

        public Customer GetCustomerById(int customerId)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}
