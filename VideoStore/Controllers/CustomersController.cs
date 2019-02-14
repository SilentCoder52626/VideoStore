using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using System.Data.Entity;
using VideoStore.ViewModel;
using AutoMapper;

namespace VideoStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageData))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageData)]
        public ActionResult CustomerForm()
        {
            var membershipType = context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipType
            };
            return View("CustomerForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = context.MembershipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
            }
            if (customer.Id == 0)
                context.Customers.Add(customer);
            else
            {
                var customerInDb = context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribed = customer.IsSubscribed;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {

                MembershipTypes = context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var customer = context.Customers.Include(c => c.MembershipType)
                .Include(c=>c.Rental).Where(c => c.Id == id);

            

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}