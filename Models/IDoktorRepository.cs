namespace hastanerandevu.Models
{
    public interface IDoktorRepository: IRepository<Doktor>
    {
        void Guncelle(Doktor doktor);
        void Kaydet();
    }
}
