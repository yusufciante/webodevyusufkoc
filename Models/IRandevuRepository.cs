namespace hospital.Models
{
    public interface IRandevuRepository : IRepository<Randevu>
    {
        void Guncelle(Randevu randevu);
        void Kaydet();
    }
}
