
// Models/VolunteerDashboardViewModel.cs
namespace YourNamespace.Models
{
    public class VolunteerDashboardViewModel
    {
        public int TaskCount { get; set; }
        public int MessageCount { get; set; }
        public IEnumerable<Task> Tasks { get; set; } // Replace with your actual task model
    }
}
