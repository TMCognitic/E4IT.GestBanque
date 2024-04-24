namespace E4IT.GestBanque.Models
{
    public interface IBanker : ICustomer
    {
        string Numero { get; }
        Personne Titulaire { get; }

        void AppliquerInteret();
    }
}