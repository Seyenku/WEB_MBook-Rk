using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MBook_Rk.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}