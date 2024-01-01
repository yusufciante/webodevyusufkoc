using hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace hospital.Utility
// veritabanında EF tablo oluşturması için ilgili model sınıflarınızı buraya eklemelisiniz
{
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<DoktorBrans> DoktorBranslari { get; set; }

        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
