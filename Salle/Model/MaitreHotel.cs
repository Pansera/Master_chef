using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Salle
{
    class MaitreHotel
    {
        public ClientConcret CL = new ClientConcret();
        public int check;
        private static MaitreHotel instance = null;
        private static readonly object padlock = new object();
        private bool CR1dispo = true;
       
        private int placeRestante;
        public Table TB = new Table();
        public ListTable place = new ListTable();
        public bool CR1 { get; set; }
        public bool CR2 { get; set; }

        public void CheckClient()
        {
            // Récupère la valeur du générateur de client
            check = CL.Arriver();

            if(check >= 1)
            {
                //Si plus de un client se présente, lance la méthode suivante
                Console.Write("Il y a " + check + " client qui viennent d'arriver. Le maitre d'hôtel va vérifier si une table est disponible");
                this.VerifieTableDisponible(check);
            }
        }
        public void VerifieTableDisponible(int check)
        {
            //On vérifie que le nombre de client est inférieur à 4
            if (check <= 4)
            {
                // On regarde si un table est disponible
                List<Table> test = TB.GetTable4();
                int exiawin = test.FindIndex(p => p.Tabledispo == true);
                //Quand FindIndex trouve une occurence, il atribue la valeur exiawin à 0
                if (exiawin == 0)
                {
                    // Si c'est le cas il va appeler le chef de rang
                    Console.Write("Une table est disponible. Le maitre d'hôtel va appeler le chef de rang.");
                    this.AppelIChefRang(test, check);
                }
            }
            // Si ya plus de 4 client on procède de la même manière
            else
            {
                List<Table> test2 = TB.GetTable8();
                int exiawin2 = test2.FindIndex(p => p.Tabledispo == true);
                if (exiawin2 == 0)
                {
                    Console.Write("Une table est disponible. Le maitre d'hôtel va appeler le chef de rang.");
                    this.AppelIChefRang(test2, check);
                }
                else
                {
                    // Sinon notre maitre d'hotel va rejeter le client
                    Console.WriteLine("Navrée Monsieur, nous avons plus de place.");
                }
            }
        }
        public void AppelIChefRang(List<Table> test, int check)
        {
            //Tout en appelant le chef de rang, à la première occurence trouver il va définir la table en occupé
            // et retirer le nombre de place de libre à la table
            Table reserver = test.Where(i => i.Tabledispo == true).First();
            var idTable = test.IndexOf(reserver);
            if(check < 4)
            {
                placeRestante = 4 - check;
            }
            else
            {
                placeRestante = 8 - check;
            }
            //La table est maintenant réservé pour les nouveaux arrivants
            test[idTable] = new Table() { Tabledispo = false };
            test[idTable] = new Table() { nbPlace = placeRestante };
            // Ici CR1dispo représente le premier Chef de rang
            // qui est attribué de base à "true"
            // si jamais un client se représente à nouveau est qu'il n'est pas disponible
            // le CR2dispo prend le relaie

            if(CR1dispo == true)
            {
                CR1 = false;
                // Ici on lance le cronstructeur qui va faire agir notre chef de rang
                ChefRang a = new ChefRang(idTable, check);
                CR1 = true;
            }
            else
            {
                CR2 = false;
                ChefRang a = new ChefRang(idTable, check);
                CR2 = true;
            }
            
           

        }
        public MaitreHotel()
        {

        }
        public static MaitreHotel GetInstance()
        {
            lock (padlock)
            {
                    if (instance == null)
                    {
                        instance = new MaitreHotel();
                    }
                    return instance;
            }
            
        }

    }

}

