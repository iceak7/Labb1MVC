﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers { get; }
        Customer GetCustomerById(int customerId);
        Customer AddCustomer(Customer customer);
        void Edit(Customer customer);
        void Delete(Customer customer);

        
    }
}
