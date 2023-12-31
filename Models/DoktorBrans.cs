using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace hastanerandevu.Models
{
    public class DoktorBrans
    {
        [Key] // pk
        public int Id { get; set; }
        [Required(ErrorMessage ="Doktor Branşı kısmı boş bırakılamaz!")] //not null
        [MaxLength(25)]
        [DisplayName("Doktor Branşı Adı")]
        public string Ad { get; set; }
    }
}