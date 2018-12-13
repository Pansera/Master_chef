using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuisine.Model;
using System.Data.SqlClient;

namespace Cuisine.Model
{
    class ChefPartie
    {
        public void Cuisiner(int id_recette)
        {
            int temps = Temps_preparation(id_recette);
            Commis.chercher_ingredients(id_recette);
            preparer(temps);
            Commis.apporter_plat();
        }

        private static void preparer(int temps)
        {
            System.Threading.Thread.Sleep(10);
        }

        private static int Temps_preparation(int id_recette)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=master_chef;Trusted_Connection=True;");
            conn.Open();

            SqlCommand temps_prep_command = conn.CreateCommand();
            temps_prep_command.CommandText = "SELECT temps FROM Recettes WHERE id = "+ id_recette;
            SqlDataReader temps_prep_reader = temps_prep_command.ExecuteReader();
            int temps_prep = temps_prep_reader.GetInt32(0);

            return temps_prep;
        }

    }
}