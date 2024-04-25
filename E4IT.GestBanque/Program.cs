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

            Personne johnDoe = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("0001", 500, johnDoe);
            Epargne epargne = new Epargne("0002", johnDoe);
            Banque banque = new Banque("Techno Banking");

            banque.Ajouter(courant);
            banque.Ajouter(epargne);

            try
            {
                Courant? c = banque["0001"] as Courant;

                if(c is not null)
                {
                    c.LigneDeCredit = -500;
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["0001"].Depot(-500);
                Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["0001"].Depot(500);
                Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["0001"].Retrait(-100);
                Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["0001"].Retrait(100);
                Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["0001"].Retrait(1000);
                Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["0001"].Retrait(500);
                Console.WriteLine($"Solde du compte '0001' : {banque["0001"].Solde}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["0002"].Depot(5000);
                Console.WriteLine($"Solde du compte '0002' : {banque["0002"].Solde}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Avoir des comptes de Mr {johnDoe.Prenom} {johnDoe.Nom} : {banque.AvoirDesCompte(johnDoe)}");

        }
    }
}
