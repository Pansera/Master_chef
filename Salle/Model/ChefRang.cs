using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Salle
{
    public class ChefRang
    {
        //public MaitreHotel MH;
        //private List<Table> test;
        
        private int carte = 40;
        private ClientConcret CC = new ClientConcret();
        public string commande;
        private Table TB = new Table();
        private Serveur SV = new Serveur();

        public ChefRang(int idTable, int check)
        {
            // Un thread va donc être créer pour actionner une liste de méthode
            Thread abc = new Thread(() => {
                AccompagneClient(idTable, check);
                PresentCarte(idTable, check);
               });
            abc.Start();
            //abc.Abort();

        }

        
        public int Carte { get => carte; set => carte = value; }

        public void AccompagneClient (int idTable, int check)
        {
            Console.WriteLine("Le chef de rang amène les " + check + " personnes à la table " + idTable);
        }
        
        public void PresentCarte(int idTable, int check)
        {
            int donnerCarte = check / 2;
            //Ici on divise par deux le nombre de client pour déterminer le nombre de carte
            //qu'on va donner aux client. A ça, on soustrait le nombre total de carte aux carte qu'on va donner
            // pour avoir un suivie des cartes
            this.Carte = this.Carte - donnerCarte;
            Console.WriteLine("Le chef de rang dépose " + donnerCarte + " cartes aux client à la table" + idTable);
            // Là le chef de rang attend 5 min pour receptionner la commande
            Thread.Sleep(5000);
            int com = CC.Commander();
            string recette = com.ToString();
            commande = "" + idTable + "" + recette;
            //On transmet la commande au chef de cuisine
            this.TransmetCommande(commande);
            // Ici le serveur dresse la table
            SV.Dresser(idTable);
            

        }
        
        public string TransmetCommande(string commande)
        {

            return commande;
        }
        

    }
}
