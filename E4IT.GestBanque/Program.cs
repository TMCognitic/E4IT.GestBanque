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

            courant.Depot(-500);
            Console.WriteLine($"Solde du compte '0001' : {courant.Solde}");
            courant.Depot(500);
            Console.WriteLine($"Solde du compte '0001' : {courant.Solde}");
            courant.Retrait(-100);
            Console.WriteLine($"Solde du compte '0001' : {courant.Solde}");
            courant.Retrait(100);
            Console.WriteLine($"Solde du compte '0001' : {courant.Solde}");
            courant.Retrait(1000);
            Console.WriteLine($"Solde du compte '0001' : {courant.Solde}");

        }
    }
}
