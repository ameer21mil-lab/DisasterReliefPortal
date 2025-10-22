using System.Collections.Generic;

namespace YourNamespace.Models
{
    public class AdminDashboardViewModel
    {
        public int VolunteerCount { get; set; }
        public int ReportCount { get; set; }
        public int DonationCount { get; set; }
        public List<ApplicationUser> Volunteers { get; set; } // Ensure ApplicationUser is correct
    }
}
