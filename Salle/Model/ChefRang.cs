using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Salle
{
    class ChefRang
    {
        //public MaitreHotel MH;
        //private List<Table> test;
        private int nbPersonne;
        private int carte = 40;
        private ClientConcret CC = new ClientConcret();
        public string commande;
        private Table TB = new Table();
        private Serveur SV = new Serveur();
        


        public ChefRang(int idTable, int check)
        {
            
            int table = idTable;
            check = nbPersonne;
            Thread abc = new Thread(() => {
                AccompagneClient(table, nbPersonne);
                PresentCarte(table, nbPersonne);
               });
            abc.Start();
            abc.Abort();

        }

        
        public int Carte { get => carte; set => carte = value; }

        public void AccompagneClient (int idTable, int check)
        {
            Console.WriteLine("Le chef de rang amène les " + check + " personnes à la table " + idTable);
        }
        
        public void PresentCarte(int idTable, int check)
        {
            int donnerCarte = check / 2;
            this.Carte = this.Carte - donnerCarte;
            Console.WriteLine("Le chef de rang dépose " + donnerCarte + " cartes aux client à la table" + idTable);
            Thread.Sleep(5000);
            int com = CC.Commander();
            string commande = com.ToString();
            this.TransmetCommande(commande);
            SV.Dresser(idTable);
            

        }
        
        public string TransmetCommande(string commande)
        {

            return commande;
        }
        

    }
}
