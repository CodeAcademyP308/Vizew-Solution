using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizew.WebUI.Models.Entity
{
    public class News : BaseEntity
    {
        [Required(ErrorMessage = "'{0}' qeyd etmək mütləqdir")]
        [StringLength(150)]
        [DisplayName("Xəbər başlığı")]
        public string Title { get; set; }
        [DisplayName("Xəbər təfərrüatı")]
        public string Body { get; set; }
        [DisplayName("Şəkil")]
        public string MediaUrl { get; set; }
        [StringLength(70)]
        [DisplayName("Müəllif")]
        public string Author { get; set; }
        [DisplayName("Növü")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [VizewSqlDefaultValue(DefaultValueSql = "1")]
        [DisplayName("Məşhur")]
        public bool IsPopular { get; set; }
    }
}