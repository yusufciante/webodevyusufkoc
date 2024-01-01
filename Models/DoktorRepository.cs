using hospital.Utility;
using hospital.Models;

namespace hospital.Models
{
    public class DoktorRepository : Repository<Doktor>, IDoktorRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public DoktorRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Doktor doktor)
        {
            _uygulamaDbContext.Update(doktor);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
