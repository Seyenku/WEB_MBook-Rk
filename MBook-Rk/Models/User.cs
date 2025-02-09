using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы users.
    /// </summary>
    [Table("users")]
    public class User : IdentityUser<int>
    {
        // Первичный ключ
        [Key]
        [Column("id")]
        public override int Id { get; set; }

        // Логин пользователя (до 50 символов)
        [Column("login")]
        [StringLength(50)]
        public override string? UserName { get; set; }

        // Пароль пользователя (до 50 символов)
        [Column("pass")]
        [StringLength(50)]
        public override string? PasswordHash { get; set; }

        // Роль пользователя
        [Column("role")]
        public int? Role { get; set; }

        public virtual ICollection<Logs>? Logs { get; set; }
    }
}
