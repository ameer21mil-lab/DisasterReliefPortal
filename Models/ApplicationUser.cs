using Microsoft.AspNetCore.Identity;

namespace YourNamespace.Models // Adjust the namespace as necessary
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        // Add the Role property
        public string Role { get; set; } // Ensure this property is included
    }
}
