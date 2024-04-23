using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4IT.GestBanque.Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();

        public string Nom { get; set; }

        public Compte this[string numero]
        {
            get
            {
                return _comptes[numero];
            }
        }

        public void Ajouter(Compte courant)
        {
            _comptes.Add(courant.Numero, courant);
        }

        public void Supprimer(string numero)
        {
            _comptes.Remove(numero);
        }

        public double AvoirDesCompte(Personne personne)
        {
            double total = 0D;

            foreach(Compte courant in _comptes.Values) 
            {
                if(courant.Titulaire == personne)
                {
                    total += courant;

                    //total (double) = total (double) + courant (Compte)
                    //public static double operator+(double d, Compte courant)
                }
            }

            return total;
        }
    }
}
