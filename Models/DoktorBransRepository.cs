using hospital.Utility;
using hospital.Models;

namespace hospital.Models
{
    public class DoktorBransRepository : Repository<DoktorBrans>, IDoktorBransRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public DoktorBransRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(DoktorBrans doktorBrans)
        {
            _uygulamaDbContext.Update(doktorBrans);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
