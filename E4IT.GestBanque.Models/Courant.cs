namespace E4IT.GestBanque.Models
{
    public class Courant
    {
        private string _numero;
        private double _solde, _ligneDeCredit;
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
                    return; //à remplacer par une erreur

                _ligneDeCredit = value;
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

        public void Retrait(double montant)
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

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant invalide");
                return;
            }

            Solde += montant;
        }
    }
}

