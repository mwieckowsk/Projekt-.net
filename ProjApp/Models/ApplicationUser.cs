using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProjApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Car> Cars { get; set; }
    }
}