using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы docs.
    /// </summary>
    [Table("docs")]
    public class Docs
    {
        // Первичный ключ
        [Key]
        [Column("dbid")]
        public int? DbId { get; set; }

        // Путь к документу
        [Column("path")]
        public string? Path { get; set; }

        // Дополнительное числовое поле
        [Column("id")]
        public int Id { get; set; }

        // ETS – строковое поле длиной до 50 символов
        [Column("ets")]
        [StringLength(50)]
        public string? Ets { get; set; }

        // Флаг наличия фото
        [Column("photo")]
        public bool? Photo { get; set; }

        // Флаг наличия скана документа
        [Column("scan_do")]
        public bool? ScanDo { get; set; }

        public virtual MBook? MBook { get; set; }
    }
}
