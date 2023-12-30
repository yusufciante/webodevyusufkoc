using hastanerandevu.Models;
using Microsoft.EntityFrameworkCore;
namespace hastanerandevu.Utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<DoktorBrans> DoktorBranslari { get; set; }
    }
}
