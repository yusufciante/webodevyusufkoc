namespace hastanerandevu.Models
{
    public interface IDoktorBransRepository: IRepository<DoktorBrans>
    {
        void Guncelle(DoktorBrans doktorBrans);
        void Kaydet();
    }
}
