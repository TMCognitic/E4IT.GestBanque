using E4IT.GestBanque.Models;

namespace E4IT.GestBanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personne johnDoe = new Personne()
            {
                Nom = "Doe",
                Prenom = "John",
                DateNaiss = new DateTime(1970, 1, 1)
            };

            Courant courant = new Courant()
            {
                Numero = "0001",
                LigneDeCredit = 500,
                Titulaire = johnDoe
            };

            Banque banque = new Banque() { Nom = "Techno Banking" };
            banque.Ajouter(courant);

            banque["0001"].Depot(-500);
            Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            banque["0001"].Depot(500);
            Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            banque["0001"].Retrait(-100);
            Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            banque["0001"].Retrait(100);
            Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            banque["0001"].Retrait(1000);
            Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            
        }
    }
}
