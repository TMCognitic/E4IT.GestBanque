using E4IT.GestBanque.Models;
using E4IT.GestBanque.Models.Divers;

namespace E4IT.GestBanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Celsius / Fahrenheit
            Celsius celsius = new Celsius() { Temperature = 24 };
            Fahrenheit fahrenheit = celsius;
            Console.WriteLine($"{celsius.Temperature}°C => {fahrenheit.Temperature}°F");

            celsius = (Celsius)fahrenheit;
            Console.WriteLine($"{fahrenheit.Temperature}°F => {celsius.Temperature}°C");
            #endregion


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

            Epargne epargne = new Epargne()
            {
                Numero = "0002",
                Titulaire = johnDoe
            };

            courant.LigneDeCredit = 500;

            Banque banque = new Banque() { Nom = "Techno Banking" };
            banque.Ajouter(courant);
            banque.Ajouter(epargne);

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
            banque["0001"].Retrait(500);
            Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");

            banque["0002"].Depot(5000);
            Console.WriteLine($"Solde du compte '0002' : {banque["0002"].Solde}");
            banque["0002"].Retrait(100);
            Console.WriteLine($"Solde du compte '0002' : {banque["0002"].Solde}");

            Console.WriteLine($"Avoir des comptes de Mr {johnDoe.Prenom} {johnDoe.Nom} : {banque.AvoirDesCompte(johnDoe)}");

        }
    }
}
