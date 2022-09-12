using Labb1MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Components
{
    public class CustomerOptions : ViewComponent
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerOptions(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IViewComponentResult Invoke()
        {
            var customers = _customerRepository.GetAllCustomers;
            return View(customers);

        }
    }
}
