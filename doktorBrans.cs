using System.ComponentModel.DataAnnotations;

namespace hastanerandevu.Models
{
    public class DoktorBrans
    {
        [Key] // pk
        public int Id { get; set; }
        [Required] //not null
        public string Ad { get; set; }
    }
}