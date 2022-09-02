using Labb1MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customersRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customersRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var customers = _customersRepository.GetAllCustomers;

            return View(customers);
        }

        public IActionResult Detail(int id)
        {
            var customer = _customersRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew([Bind("Name, PhoneNr, City, Address, ZipCode")]Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customersRepository.AddCustomer(customer);

                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }
    }
}
