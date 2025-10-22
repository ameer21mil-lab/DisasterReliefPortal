using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
