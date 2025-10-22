using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using YourNamespace.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourNamespace.ViewModels;
using Task = YourNamespace.Models.Task;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YourNamespace.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var volunteers = await _userManager.GetUsersInRoleAsync("Volunteer");

            var model = new AdminDashboardViewModel
            {
                VolunteerCount = volunteers.Count(),
                ReportCount = await _context.IncidentReports.CountAsync(),
                DonationCount = await _context.Donations.CountAsync(),
                Volunteers = volunteers.ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> ViewIncidentReports()
        {
            var incidentReports = await _context.IncidentReports
                .Select(report => new IncidentReport
                {
                    Id = report.Id,
                    Title = report.Title ?? "No Title",
                    Description = report.Description ?? "No Description",
                    Location = report.Location ?? "No Location",
                    DateSubmitted = report.DateSubmitted
                })
                .ToListAsync();

            return View(incidentReports);
        }

        [HttpGet]
        public async Task<IActionResult> AllocateTasks()
        {
            var volunteers = await _userManager.GetUsersInRoleAsync("Volunteer");
            
            var model = new TaskViewModel
            {
                VolunteerSelectList = volunteers.Select(v => new SelectListItem
                {
                    Value = v.Id,
                    Text = v.UserName ?? v.Email
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AllocateTasks(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var task = new Task
                {
                    Name = model.TaskName,
                    Description = model.TaskDescription,
                    DueDate = model.DueDate,
                    Progress = model.Progress,
                    AssignedToUserId = model.AssignedToUserId
                };

                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                return RedirectToAction("Dashboard");
            }

            var volunteers = await _userManager.GetUsersInRoleAsync("Volunteer");
            model.VolunteerSelectList = volunteers.Select(v => new SelectListItem
            {
                Value = v.Id,
                Text = v.UserName ?? v.Email
            }).ToList();

            return View(model);
        }

        public async Task<IActionResult> ViewDonations()
        {
            var donations = await _context.Donations
                .Select(d => new Donation
                {
                    Id = d.Id,
                    Amount = d.Amount,
                    Type = d.Type ?? "No type specified",
                    Description = d.Description ?? "No description available",
                    Date = d.Date
                })
                .ToListAsync();

            return View(donations);
        }

        public IActionResult SendMessage() => View();
    }
}