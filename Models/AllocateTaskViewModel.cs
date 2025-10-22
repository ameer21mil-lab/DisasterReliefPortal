using Microsoft.AspNetCore.Mvc.Rendering;

namespace YourNamespace.Models
{
    public class AllocateTaskViewModel
    {
        public string TaskName { get; set; } // Example property
        public string Description { get; set; } // Example property
        public string AssignedToUserId { get; set; } // Property to capture the ID of the user the task is assigned to
        public DateTime Deadline { get; set; } // Example property for task deadline
                                    // Add any other properties you need for task allocation
        public int VolunteerId { get; set; }
        public int TaskId { get; set; }
        public List<SelectListItem> Volunteers { get; set; }
        }
    }