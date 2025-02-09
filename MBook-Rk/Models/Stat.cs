using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы stat.
    /// </summary>
    [Table("stat")]
    public class Stat
    {
        // Ключ статистики (до 50 символов)
        [Key]
        [Column("tkey")]
        [StringLength(50)]
        public required string TKey { get; set; }

        // Значение статистики
        [Column("value")]
        public int? Value { get; set; }
    }
}
