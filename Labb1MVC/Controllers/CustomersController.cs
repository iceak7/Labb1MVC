using Labb1MVC.Models;
using Labb1MVC.ViewModels;
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
        private readonly IBookBorrowRepository _bookBorrowRepository;

        public CustomersController(ICustomerRepository customerRepository, IBookBorrowRepository bookBorrowRepository)
        {
            _customersRepository = customerRepository;
            _bookBorrowRepository = bookBorrowRepository;
        }
        public IActionResult Index()
        {
            var customers = _customersRepository.GetAllCustomers;

            return View(customers);
        }

        public IActionResult Detail(int id, string mes)
        {
            var customer = _customersRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            if (mes != null)
            {
                ViewData["StudentDetailMessage"] = mes;
            }

            var bookBorrows = _bookBorrowRepository.GetBookBorrowsByCustomer(id);

            return View(new CustomerDetailViewModel
            {
                Customer = customer,
                BookBorrows = bookBorrows.ToList()
            }); 
        }

        [HttpGet]
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
                var createdCustomer = _customersRepository.AddCustomer(customer);

                return RedirectToAction(nameof(Detail), new { id = createdCustomer.CustomerId, mes= "Customer Added" });
            }
            return View(customer);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var studentToUpdate = _customersRepository.GetCustomerById(id);

            if(studentToUpdate == null)
            {
                return NotFound();
            }
            return View(studentToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("CustomerId, Name, PhoneNr, City, Address, ZipCode")] Customer customer)
        {

            if (ModelState.IsValid)
            {
                var updatedCustomer = _customersRepository.Edit(customer);
                return RedirectToAction(nameof(Detail), new { id = updatedCustomer.CustomerId, mes = "Customer Updated" });
            }

            return View(customer);

        }




        public IActionResult Delete(int id)
        {

            var customerToDelete = _customersRepository.GetCustomerById(id);

            if (customerToDelete != null)
            {
                _customersRepository.Delete(customerToDelete);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
           
           

        }
    }
}
