using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YourNamespace.Models;

namespace YourNamespace.Models
{
    public class TaskViewModel
    {
        [Required(ErrorMessage = "Task name is required")]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string TaskDescription { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        [Display(Name = "Due Date")]
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }

        [Display(Name = "Progress Status")]
        public string Progress { get; set; } = "Pending";

        [Required(ErrorMessage = "Please select a volunteer")]
        [Display(Name = "Assign To Volunteer")]
        public string AssignedToUserId { get; set; }

        public List<SelectListItem> VolunteerSelectList { get; set; } = new List<SelectListItem>();
    }
}