using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    //Création du model abstrait héritant de la classe "Observer"
    public abstract class AbstractModel : Observer
    {
        protected string commande = "";
        

        public abstract void getCommande(string result);


      
    }
}
