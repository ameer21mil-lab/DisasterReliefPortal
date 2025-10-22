namespace WebApplication1.Models
{
    public class SubmitReportViewModel
    {
        public string Title { get; set; }  // Title of the incident
        public string Description { get; set; } // Description of the incident
        public string Location { get; set; } // Location of the incident
        public DateTime DateReported { get; set; } // Date when the incident is reported
    }
}
