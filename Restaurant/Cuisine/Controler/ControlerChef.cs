using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;

namespace Restaurant.Controler
{
    //La classe qui hérite de l'AbstractControler et prend le model en paramètre super
    class ControlerChef : AbstractControler
    {
        public ControlerChef(AbstractModel cuisine) : base(cuisine)
        {

        }


        public override void Control()
        {    
            //Si il y a une entre sur la pile, récupérer les entrees une a une, les envoyes au chef de cuisine et les supprimer de la list
            if (Commandes.Any())
            {
                int count = Commandes.Count;
                    
                for (int i = 0; i < count; i++)
                {
                    
                    string First = Commandes.First();
                    delCommande(First);
                    cuisine.getCommande(First);
                }
            }                     
        }
    }
}
