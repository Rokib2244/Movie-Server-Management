using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RokibPlusNet.Models;
using RokibPlusNet.ViewModels;

namespace RokibPlusNet.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
       
        protected override void Dispose(bool disposing)
        {
            
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);

        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel {
                
                    Customer=customer,
                    MembershipTypes=_context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.CustomerId==0)
                _context.Customers.Add(customer);


            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId);
                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewslatter = customer.IsSubscribedToNewslatter;


            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
            public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //ViewBag.Customers = customers Include(c=>c.MembershipType);
            //return View(customers);
            return View();
        }
        public ActionResult Details(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
                return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()           
            };
            return View("CustomerForm", viewModel);

        }


            //private IEnumerable<Customer> GetAllCustomers()
            //{
            //    var customers = new List<Customer> {
            //    new Customer { CustomerId =1, CustomerName=" Haris"},
            //    new Customer { CustomerId =2, CustomerName="Munna"},
            //    new Customer { CustomerId =3, CustomerName="Ashafak"},
            //    new Customer { CustomerId =4, CustomerName="Salam"},
            //    new Customer { CustomerId =5, CustomerName="Borkot"}
            //    };
            //    return customers;
            //}

        }
}