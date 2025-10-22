using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models; // Ensure this namespace includes your view models
using YourNamespace.Data;   // This should include your DbContext
using System.Linq;         // For LINQ queries
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims; // For async operations
using WebApplication1.Models;  
using Task = YourNamespace.Models.Task;


namespace YourNamespace.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _context; // my DbContext
        private readonly UserManager<ApplicationUser> _userManager; // UserManager for ApplicationUser

        public VolunteerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get tasks assigned to this volunteer
            var tasks = await _context.Tasks
                .Where(t => t.AssignedToUserId == user.Id)
                .OrderByDescending(t => t.DueDate)
                .ToListAsync();
            // Other properties can be set here as needed


            return View(tasks);
        }
   

        // Action to display the form for submitting an incident report
        public IActionResult SubmitReport()
        {
            var model = new SubmitReportViewModel();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SubmitReport(SubmitReportViewModel model)
        {
            // Fetch the logged-in user's ID (this assumes you're using ASP.NET Core Identity)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // The logged-in user's ID as a string

            // Convert userId to Guid (since SubmittedByUserId is of type Guid)
            var submittedByUserId = Guid.Parse(userId);  // Make sure userId is not null or empty

            // Now create the new IncidentReport and assign the user ID, title, and location
            var incidentReport = new IncidentReport
            {
                Title = model.Title, // Set the Title
                Description = model.Description,
                Location = model.Location, // Set the Location
                DateSubmitted = DateTime.Now, // Current timestamp
                SubmittedByUserId = submittedByUserId, // Set the logged-in user ID
                                                       // Set any other properties from the view model
                Status = "Open"
            };

            // Add the incident report to the context
            _context.IncidentReports.Add(incidentReport);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect or return a result
            return RedirectToAction("Index", "Home"); // Or wherever you want to navigate after submission
        }

        [HttpGet]
        public async Task<IActionResult> ViewTasks()
        {
            // Fetch tasks from the database
            var tasks = await _context.Tasks.ToListAsync();

            if (tasks == null || !tasks.Any())
            {
                // Option 1: Show message in the same view
                ViewData["NoTasksMessage"] = "Currently, you don't have any assigned tasks.";
            }

            // Return the same view with tasks (or empty tasks)
            return View(tasks);
        }

    }
}
