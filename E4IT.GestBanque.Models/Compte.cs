namespace E4IT.GestBanque.Models
{
    public abstract class Compte : ICustomer, IBanker
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

        public virtual double LigneDeCredit
        {
            get { return 0; }
            set 
            {
                Console.WriteLine("La ligne de crédit ne peut pas être définie...");
                return;
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
            if (montant <= 0)
            {
                Console.WriteLine("montant invalide");
                return;
            }

            if (Solde - montant < -LigneDeCredit)
            {
                Console.WriteLine("Solde insuffisant");
                return;
            }

            Solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }
    }
}