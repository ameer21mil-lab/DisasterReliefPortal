using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using YourNamespace.Data;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("Home/MakeDonation")]
        // GET: /Donations/MakeDonation
        [HttpGet]
        public IActionResult MakeDonation()
        {
            return View();
        }
        [Route("Home/MakeDonation")]
        // POST: /Donations/MakeDonation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeDonation(Donation model)
        {
            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // Set the current date and time
                model.Date = DateTime.Now;

                // Add the donation to the database context
                _context.Donations.Add(model);

                // Save the changes to the database
                await _context.SaveChangesAsync();

                // Redirect to a "Thank You" page after donation is saved
                return RedirectToAction("ThankYou");
            }

            // If the model is not valid, return the same view with validation messages
            return View(model);
        }

        // A simple "Thank You" page after donation is made
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}