using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
         
        // Index page
        public IActionResult Index()
        {
            return View();
        }
        // Register page
        public IActionResult Register()
        {
            return View();
        }
     
        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }
        // Admin landing page
        public IActionResult AdminLanding()
        {
            return View();
        }

        // Volunteer landing page
        public IActionResult VolunteerLanding()
        {
            return View();
        }

        // Donor landing page
        public IActionResult DonorLanding()
        {
            return View();
        }

       

        [HttpGet]
        public IActionResult MakeDonation()
        {
            return View();
        }

        // This handles form submission (if applicable)
        [HttpPost]
        public IActionResult SubmitDonation(DonationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the donation (e.g., save to the database)
                // Redirect or display success message
                return RedirectToAction("DonationSuccess");
            }

            // Return the view again with validation errors if the model is invalid
            return View("MakeDonation", model);
        }

        [HttpPost]
        public IActionResult Donate(DonationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process donation logic here (e.g., save to database)

                // Option 1: Pass success message to the same view
                TempData["DonationSuccessMessage"] = "Thank you for your donation!";

                return RedirectToAction("DonationSuccess", "Home"); // Redirect back to the donate form or any other view
            }

            return View(model); // Return the view if validation fails
        }


        // Optionally, a success page after the donation
        public IActionResult DonationSuccess()
        {
            return View();
        }
    }
}
