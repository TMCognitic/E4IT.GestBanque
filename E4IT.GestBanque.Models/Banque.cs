using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4IT.GestBanque.Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes;

        public string Nom { get; init; }

        public Compte this[string numero]
        {
            get
            {
                return _comptes[numero];
            }
        }

        public Banque(string nom)
        {
            Nom = nom;
            _comptes = new Dictionary<string, Compte>();
        }

        public void Ajouter(Compte compte)
        {
            compte.PassageEnNegatifEvent += PassageEnNegatifAction;
            _comptes.Add(compte.Numero, compte);
        }        

        public void Supprimer(string numero)
        {
            if(!_comptes.ContainsKey(numero))
            {
                return;
            }

            _comptes[numero].PassageEnNegatifEvent -= PassageEnNegatifAction;
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

        private void PassageEnNegatifAction(Compte compte)
        {
            Console.WriteLine($"Le compte '{compte.Numero}' vient de passer en négatif");
        }
    }
}
