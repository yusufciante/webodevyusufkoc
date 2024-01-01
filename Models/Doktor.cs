using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.Models
{
    public class Doktor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string DoktorAdi { get; set; }

        public string Poliklinik { get; set; }

        public string DoktorMesai { get; set; }

        [ValidateNever]
        public int doktorBransId { get; set; }
        [ForeignKey("doktorBransId")]

        [ValidateNever]
        public DoktorBrans DoktorBrans { get; set; }
        [ValidateNever]
        public string ResimUrl { get; set; }
    }
}
