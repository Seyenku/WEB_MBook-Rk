using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы pages.
    /// </summary>
    [Table("pages")]
    public class Page
    {
        // Первичный ключ
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Название страницы
        [Column("name")]
        public string? Name { get; set; }

        // Контент страницы
        [Column("contentt")]
        public string? Content { get; set; }
    }
}
