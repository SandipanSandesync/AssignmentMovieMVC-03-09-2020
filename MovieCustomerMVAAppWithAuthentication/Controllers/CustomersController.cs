﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using MovieCustomerMVAAppWithAuthentication.Models;
using MovieCustomerMVAAppWithAuthentication.ViewModel;

namespace MovieCustomerMVAAppWithAuthentication.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(singleCustomer==null)
               return HttpNotFound();
            return View(singleCustomer);
            
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewmodel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
           if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New",viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(p => p.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
      
        public ActionResult Edit(int id)
        {
            var updateCust = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(updateCust==null)
            {
                return HttpNotFound();
            }
            var vm = new NewCustomerViewModel
            {
                Customer = updateCust,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New",vm);
        }
        public ActionResult Delete(int id)
        {
            var cust = _context.Customers.Find(id);
            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        
       

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}