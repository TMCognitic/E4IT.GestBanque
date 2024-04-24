namespace E4IT.GestBanque.Models
{
    public class Epargne : Compte
    {
        private DateTime _dernierRetrait;

        public DateTime DernierRetrait
        {
            get
            {
                return _dernierRetrait;
            }

            private set
            {
                _dernierRetrait = value;
            }
        }        

        public override void Retrait(double montant)
        {
            double ancientSolde = Solde;
            base.Retrait(montant);

            if(ancientSolde != Solde)
            {
                DernierRetrait = DateTime.Now;
            }
        }

        protected override double CalculInteret()
        {
            return Solde * .045;
        }
    }
}

