using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы heroes.
    /// </summary>
    [Table("heroes")]
    public class Hero
    {
        // Первичный ключ
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Фамилия Героя (до 50 символов)
        [Column("surname")]
        [StringLength(50)]
        public string? Surname { get; set; }

        // Имя Героя (до 50 символов)
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }

        // Отчество Героя (до 50 символов)
        [Column("middlename")]
        [StringLength(50)]
        public string? Middlename { get; set; }

        // Фото Героя (хранится как путь или имя файла, до 50 символов)
        [Column("photo")]
        [StringLength(50)]
        public string? Photo { get; set; }

        // Год рождения
        [Column("yearbirth")]
        public int? YearBirth { get; set; }

        // Год смерти
        [Column("yeardeath")]
        public int? YearDeath { get; set; }

        // Описание Героя (тип text)
        [Column("description", TypeName = "text")]
        public string? Description { get; set; }

        // Внешний ключ к таблице mbook
        [Column("mbook_id")]
        public int? MBookId { get; set; }

        // Свойство для связи с mbook
        [ForeignKey("MBookId")]
        public virtual MBook? MBook { get; set; }
    }
}
