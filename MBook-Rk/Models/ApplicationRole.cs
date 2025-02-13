using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        [NotMapped] // Указывает EF не учитывать это поле при создании таблицы
        public override string NormalizedName { get => base.NormalizedName; set => base.NormalizedName = value; }
    }
}