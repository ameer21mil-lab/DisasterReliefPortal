using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage = "Please select a recipient.")]
        public string Recipient { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        public string Message { get; set; }

        public List<SelectListItem> RecipientOptions { get; set; }
    }
}
