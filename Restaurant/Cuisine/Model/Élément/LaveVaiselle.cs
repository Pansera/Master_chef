using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cuisine.Model
{
    class LaveVaiselle : IElement
    {
        static private bool _quitter = false;
        static private bool occuper;
        private bool aLaver = false;
        static private int couvertsPropre = 0;
        static private int couvertsALaver = 0;
        static private int verresPropre = 0;
        static private int verresALaver = 0;
        static private int assietesPropre = 0;
        static private int assiettesALaver = 0;
        public const int CAPACITE_MAX_COUVERTS = 24;
        public const int CAPACITE_MAX_ASSIETES = 24;
        public const int CAPACITE_MAX_VERRES = 24;
        static private int nbreTotal = 0;

        public bool ALaver { get => aLaver; set => aLaver = value; }
        static public bool Occuper { get => occuper; set => occuper = value; }
        static public int CouvertsPropres { get => couvertsPropre; set => couvertsPropre = value; }
        static public int CouvertsALaver { get => couvertsALaver; set => couvertsALaver = value; }
        static public int VerresPropres { get => verresPropre; set => verresPropre = value; }
        static public int VerresALaver { get => verresALaver; set => verresALaver = value; }
        static public int AssiettesPropres { get => assietesPropre; set => assietesPropre = value; }
        static public int AssiettesALaver { get => assiettesALaver; set => assiettesALaver = value; }
        static public bool Quitter { get => _quitter; set => _quitter = value; }
        static public int NbreTotal { get => nbreTotal; set => nbreTotal = value; }

        static public void Start()
        {
            NbreTotal = CouvertsALaver + AssiettesALaver + VerresALaver;
            if (NbreTotal == 0)
            {
                Console.WriteLine("Machine à laver vide!");
                Occuper = false;
            }
            else if (CouvertsALaver > CAPACITE_MAX_COUVERTS)
            {
                Console.WriteLine("Trop de couverts danse le lave-vaiselle !");
                Occuper = false;
            }
            else if (VerresALaver > CAPACITE_MAX_COUVERTS)
            {
                Console.WriteLine("Trop de verres dans le lave-vaiselle !");
                Occuper = false;
            }
            else if (CouvertsALaver > CAPACITE_MAX_COUVERTS)
            {
                Console.WriteLine("Trop de couverts dans le lave-vaiselle !");
                Occuper = false;
            }
            else
            {
                Occuper = true;
                Console.WriteLine("Lancement de la machine à laver");
                Thread thLave = new Thread(Nettoie);
            }
        }

        static public void Nettoie()
        {
            Quitter = false;
            while (Quitter == false)
            {
                Console.WriteLine("Lavage en cours");
                Thread.Sleep(15000);
                AssiettesPropres = AssiettesPropres + AssiettesALaver;
                VerresPropres = VerresPropres + VerresALaver;
                CouvertsPropres = CouvertsPropres + CouvertsALaver;
                CouvertsALaver = 0;
                VerresALaver = 0;
                AssiettesPropres = 0;
                Console.WriteLine("Lavage terminer");
                Quitter = true;
            }
            Occuper = false;
        }
        static public void Stop()
        {
            Quitter = true;
        }

        public void Utiliser()
        {
            Console.WriteLine("Lave-vaiselle en cours d'utilisation");
        }
    }
}
