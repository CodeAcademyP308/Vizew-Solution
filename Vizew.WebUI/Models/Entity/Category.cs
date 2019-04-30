using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizew.WebUI.Models.Entity
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "'{0}' qeyd etmək mütləqdir")]
        [StringLength(150)]
        [DisplayName("Kategoriya")]
        public string Name { get; set; }

        [DisplayName("Aktivdir")]
        public bool IsActive { get; set; }
        public virtual ICollection<News> News { get; set; }

        /*
         enable-migrations
         add-migration
         update-database
         */
    }
}