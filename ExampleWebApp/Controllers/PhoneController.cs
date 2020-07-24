using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebApp.EntityModels;
using ExampleWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApp
{
    public class PhoneController : Controller
    {
        private readonly PhoneContext _context;
        public PhoneController(PhoneContext context)
        {
            _context = context;
        }
        // GET: PhoneController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PhoneController/Details/5
        public ActionResult Details(int id)
        {
            var phone = _context.Phones.Single(x => x.PhoneId == id);
            var phoneViewModel = new PhoneViewModel()
            {
                ManufacturerName = phone.Manufacturer.Name,
                Name = phone.Name,
                OperatingSystem = phone.OperatingSystem
            };
            return View(phoneViewModel);
        }

        // GET: PhoneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // The HttpPost attribute says here that if you post against this same endpoint, it will look for forms.
        // Typically you would actually pass a ViewModel like PhoneViewModel back and store data from that model.
        // POST: PhoneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // Processing your form goes here.
                // When you're done, Redirect to the Phone index page.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // If your save fails, just try to reload the page.
                return View();
            }
        }

        // GET: PhoneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhoneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // Use the ID to find the phone you want, then update it with Entity Framework,
                // then save it back to the database.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneController/Delete/5
        public ActionResult Delete(int id)
        {
            // This would be useful for a delete confirmation page.
            return View();
        }

        // POST: PhoneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Use the ID to find the record you want to delete, then update it in Entity Framework,
                // then save the deletion back to the database.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
