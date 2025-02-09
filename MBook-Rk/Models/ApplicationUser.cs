using Microsoft.AspNetCore.Identity;

namespace MBook_Rk.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int Role { get; set; }
    }
}