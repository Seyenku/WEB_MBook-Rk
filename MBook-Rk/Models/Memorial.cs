using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы memorial.
    /// </summary>
    [Table("memorial")]
    public class Memorial
    {
        // Первичный ключ
        [Key]
        [Column("dbid")]
        public int DbId { get; set; }

        // Вторичный идентификатор (числовой)
        [Column("mid")]
        public int? Mid { get; set; }

        [Column("mentity")]
        public string? MEntity { get; set; }

        [Column("mheader")]
        public string? MHeader { get; set; }

        [Column("mfamily")]
        public string? MFamily { get; set; }

        [Column("mname")]
        public string? MName { get; set; }

        [Column("mmiddlename")]
        public string? MMiddlename { get; set; }

        [Column("mbirthday")]
        public string? MBirthday { get; set; }

        [Column("mbirthplace")]
        public string? MBirthplace { get; set; }

        [Column("mdraftplace")]
        public string? MDraftPlace { get; set; }

        [Column("mlastplace")]
        public string? MLastPlace { get; set; }

        [Column("mrank")]
        public string? MRank { get; set; }

        [Column("mpost")]
        public string? MPost { get; set; }

        [Column("mreasonout")]
        public string? MReasonOut { get; set; }

        [Column("mdatedeath")]
        public string? MDateDeath { get; set; }

        [Column("mdateout")]
        public string? MDateOut { get; set; }

        [Column("mplaceout")]
        public string? MPlaceOut { get; set; }

        [Column("mgraveplace")]
        public string? MGravePlace { get; set; }

        [Column("mfromgrave")]
        public string? MFromGrave { get; set; }

        [Column("mhospital")]
        public string? MHospital { get; set; }

        [Column("mcamp")]
        public string? MCamp { get; set; }

        [Column("mplacecapt")]
        public string? MPlaceCapt { get; set; }

        [Column("mdatecapt")]
        public string? MDateCapt { get; set; }

        [Column("mdestiny")]
        public string? MDestiny { get; set; }

        [Column("mrelative")]
        public string? MRelative { get; set; }

        [Column("maddinfo")]
        public string? MAddInfo { get; set; }

        [Column("msource")]
        public string? MSource { get; set; }

        // Изображение в виде бинарных данных
        [Column("img")]
        public byte[]? Img { get; set; }

        public virtual MBook? MBook { get; set; }
    }
}
