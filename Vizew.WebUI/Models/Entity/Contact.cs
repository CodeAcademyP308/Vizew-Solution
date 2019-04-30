using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizew.WebUI.Models.Entity
{
    public class Contact : BaseEntity
    {
        [Required]
        [DisplayName("Şəxs")]
        [StringLength(70)]
        public string Name { get; set; }
        [EmailAddress]
        [DisplayName("Elektron poçt")]
        public string Email { get; set; }
        [Required]
        [StringLength(300)]
        [DisplayName("Müraciətin məzmunu")]
        public string Message { get; set; }
        [ScaffoldColumn(false)]
        public bool IsReady { get; set; }
        [DisplayName("Cavablandırılma tarixi")]
        public DateTime? Answered { get; set; }
        [DisplayName("Cavab mətni")]
        public string AnsweredMessage { get; set; }
    }
}