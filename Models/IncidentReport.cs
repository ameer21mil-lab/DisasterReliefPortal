using YourNamespace.Models;

namespace WebApplication1.Models
{
   public class IncidentReport
{
    public int Id { get; set; }

    public string Title { get; set; } // New field
    public string Description { get; set; }
    public DateTime DateSubmitted { get; set; }
        public string Status { get; set; } = "Pending";

        public string Location { get; set; } // New field

    public Guid SubmittedByUserId { get; set; } // This should be a Guid if using uniqueidentifier in SQL

    // Other properties...
}
}

