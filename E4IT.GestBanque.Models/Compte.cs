namespace E4IT.GestBanque.Models
{
    public class Compte
    {
        public static double operator +(double d, Compte courant)
        {
            return (d < 0 ? 0 : d) + (courant.Solde < 0 ? 0 : courant.Solde);
        }

        private string _numero;
        private double _solde;
        private Personne _titulaire;

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            set
            {
                _titulaire = value;
            }
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant invalide");
                return;
            }

            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0);
        }

        private protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant invalide");
                return;
            }

            if (Solde - montant < -ligneDeCredit)
            {
                Console.WriteLine("Solde insuffisant");
                return;
            }

            Solde -= montant;
        }
    }
}