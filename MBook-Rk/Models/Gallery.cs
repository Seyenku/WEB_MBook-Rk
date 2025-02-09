using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы gallery.
    /// </summary>
    [Table("gallery")]
    public class Gallery
    {
        // Первичный ключ
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        // Идентификатор родительского элемента
        [Column("parentID")]
        public int? ParentId { get; set; }

        // Подпись или описание
        [Column("caption")]
        public string? Caption { get; set; }

        // Имя файла (до 255 символов)
        [Column("fname")]
        [StringLength(255)]
        public string? FileName { get; set; }

        // Тип файла
        [Column("ftype")]
        public int? FileType { get; set; }

        public virtual ICollection<Gallery>? Children { get; set; }
        public virtual Gallery? Parent { get; set; }
    }
}
