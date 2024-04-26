namespace E4IT.GestBanque.Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        public static double operator +(double d, Compte courant)
        {
            return (d < 0 ? 0 : d) + (courant.Solde < 0 ? 0 : courant.Solde);
        }

        public event PassageEnNegatifDelegate PassageEnNegatifEvent;

        private string _numero;
        private double _solde;
        private Personne _titulaire;

        public string Numero
        {
            get
            {
                return _numero;
            }

            private set
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

            private set
            {
                _titulaire = value;
            }
        }

        protected Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        protected Compte(string numero, Personne titulaire, double solde)
            : this(numero, titulaire)
        {
            Solde = solde;
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "le 'montant' doit être supérieur à zéro");
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
                throw new ArgumentOutOfRangeException(nameof(montant), "le 'montant' doit être supérieur à zéro");
            }

            if (Solde - montant < -ligneDeCredit)
            {
                throw new SoldeInsuffisantException($"Le solde du compte '{Numero}' est insuffisant");
            }

            Solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }

        protected void RaisePassageEnNegatifEvent()
        {
            PassageEnNegatifEvent?.Invoke(this);
        }
    }
}