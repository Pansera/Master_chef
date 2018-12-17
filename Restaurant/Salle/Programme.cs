using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Controler;
using Salle.Model;

namespace Salle
{
    class Programme
    {
        public static int Main(String[] args)
        {
            //Instancier le model avec le chef de cuisine
            //AbstractModel model = new Serveur();
            //Intancier le controler avec le model en paramètre
            //AbstractControler controler = new ControlerServeur(model);
            //Intancier la vue(le socket client) avec le controler en paramètre
            Comptoir comptoir = new Comptoir(/*controler*/);
            //Ajouter la vue en observateur du model
            //model.addObservateur(comptoir);

            Console.ReadKey();

            return 0;
        }
    }
}
