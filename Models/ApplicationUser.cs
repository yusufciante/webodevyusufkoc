using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace hospital.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public int Hastano {  get; set; }

        public string? Adres {  get; set; }

    }
}
