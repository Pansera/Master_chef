<<<<<<< HEAD:Restaurant/Cuisine/Program.cs
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Controler;
using Restaurant.Model;

namespace Restaurant
{
    class Programme
    {
        public static int Main(String[] args)
        {
            //Instancier le model avec le chef de cuisine
            AbstractModel model = new Chef_de_cuisine();
            //Intancier le controler avec le model en paramètre
            AbstractControler controler = new ControlerChef(model);
            //Intancier la vue(le socket client) avec le controler en paramètre
            Comptoir comptoir = new Comptoir(controler);
            //Ajouter la vue en observateur du model
            model.addObservateur(comptoir);

            Console.ReadKey();

            return 0;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
>>>>>>> master:Cuisine/Program.cs
