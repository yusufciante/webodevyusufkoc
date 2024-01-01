

namespace hospital.Models
{
    public interface IDoktorBransRepository : IRepository<DoktorBrans>
    {
        void Guncelle(DoktorBrans doktorBrans);
        void Kaydet();
    }
}
