using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы news.
    /// </summary>
    [Table("news")]
    public class News
    {
        // Первичный ключ
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Заголовок новости
        [Column("title")]
        public string? Title { get; set; }

        // Дата новости (хранится как строка)
        [Column("datee")]
        public string? Date { get; set; }

        // Краткий текст новости
        [Column("text_short")]
        public string? TextShort { get; set; }

        // Полный текст новости (тип text)
        [Column("text_new", TypeName = "text")]
        public string? TextNew { get; set; }

        // Источник новости
        [Column("source")]
        public string? Source { get; set; }

        // Изображение в виде бинарных данных
        [Column("image")]
        public byte[]? Image { get; set; }
    }
}
