using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;

namespace Restaurant.Controler

{
    public abstract class AbstractControler
    {
        protected AbstractModel cuisine;
        //Creation de la liste de commandes
        protected List<string> Commandes = new List<string>();


        public AbstractControler(AbstractModel cuisine)
        {
            this.cuisine = cuisine;
        }     
        //Méthode permettant de rajouter un string a la list et de l'envoyer au chef de cuisine
        public void addCommande(string commande)
        {
            Commandes.Add(commande);
            
            Control(); 

        }

        //Permet de supprimer la première occurence de commande sur la pile
        public void delCommande(string commande)
        {
            Commandes.Remove(commande);
        }

        public abstract void Control();

    }
}
