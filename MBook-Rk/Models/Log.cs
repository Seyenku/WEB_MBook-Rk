using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы logs.
    /// </summary>
    [Table("logs")]
    public class Logs
    {
        // Первичный ключ
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Идентификатор пользователя
        [Column("userId")]
        public int UserId { get; set; }

        // Описание действия
        [Column("action")]
        public required string Action { get; set; }

        // Идентификатор записи, над которой выполнено действие
        [Column("idRecord")]
        public int RecordId { get; set; }

        // Дата и время действия
        [Column("ddate")]
        public DateTime Date { get; set; }

        public virtual User? Users { get; set; }
    }
}
