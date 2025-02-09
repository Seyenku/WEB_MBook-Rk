using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBook_Rk.Models
{
    /// <summary>
    /// Модель для таблицы mbook.
    /// </summary>
    [Table("mbook")]
    public class MBook
    {
        // Первичный ключ С возможным значением NULL
        [Key]
        [Column("dbid")]
        public int? DbId { get; set; }

        [Column("mid")]
        public string? Mid { get; set; }

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

        [Column("mdatecamp")]
        public string? MDateCamp { get; set; }

        [Column("mplacecamp")]
        public string? MPlaceCamp { get; set; }

        [Column("mdestiny")]
        public string? MDestiny { get; set; }

        [Column("mrelative")]
        public string? MRelative { get; set; }

        [Column("maddinfo")]
        public string? MAddInfo { get; set; }

        [Column("msource")]
        public string? MSource { get; set; }

        // Флаг верификации
        [Column("verify")]
        public bool? Verify { get; set; }

        // Изображение в виде байтов
        [Column("img")]
        public byte[]? Img { get; set; }

        // Флаг для упорядочивания героев
        [Column("heroes_order")]
        public bool? HeroesOrder { get; set; }

        // Флаг социальной принадлежности героев
        [Column("heroes_soc")]
        public bool? HeroesSoc { get; set; }

        // Изображение (хранится как строка, например, путь или URL)
        [Column("image")]
        public string? Image { get; set; }

        // Флаги принадлежности к разным категориям
        [Column("pop_av")]
        public bool? PopAv { get; set; }

        [Column("pop_ak")]
        public bool? PopAk { get; set; }

        [Column("pop_zhp")]
        public bool? PopZhp { get; set; }

        [Column("pop_pr")]
        public bool? PopPr { get; set; }

        [Column("pop_sc")]
        public bool? PopSc { get; set; }

        [Column("pop_hs")]
        public bool? PopHs { get; set; }

        [Column("peoples_choices")]
        public bool? PeoplesChoices { get; set; }

        [Column("victory_parade_participants")]
        public bool? VictoryParadeParticipants { get; set; }

        // Свойство для связи с героями, если требуется установить отношение «один ко многим»
        public ICollection<Hero>? Heroes { get; set; }
    }
}
