namespace E4IT.GestBanque.Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                //Coder de manière defensive
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit doit être strictement positive");

                _ligneDeCredit = value;
            }
        }
        
        public Courant(string numero, Personne titulaire) 
            : base(numero, titulaire)
        {
        }

        public Courant(string numero, Personne titulaire, double solde) 
            : base(numero, titulaire, solde)
        {
            
        }

        public Courant(string numero, double ligneDeCredit, Personne titulaire)
            : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public override void Retrait(double montant)
        {
            Retrait(montant, LigneDeCredit);
        }

        protected override double CalculInteret()
        {
            return Solde * (Solde < 0 ? .0975 : .03);
        }
    }
}

