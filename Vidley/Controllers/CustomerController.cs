using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;
using System.Data.Entity;

namespace Vidley.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            //IEnumerable<Customer> customers = GetCustomers();
            //var customers = _context.Customers.Include(c=> c.MemberShipType).ToList();
            //return View(customers);
            return View();
        }

        public ActionResult New()
        {
            var membershiptypes = _context.MemberShipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MemberShipTypes = membershiptypes
            };
            
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("CUstomerForm", viewModel);
            } 
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Dob = customer.Dob;
                customerInDb.MemberShipTypeId    = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c=> c.MemberShipType).FirstOrDefault(a => a.Id == id);
            return View(customer);
        }

        //public List<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id= 1, Name = "Jhon"},
        //        new Customer{Id= 2, Name = "Sudo"}
        //    };
           
        //}
            
    }
}