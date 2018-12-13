using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cuisine.Model
{
    class Commis
    {
        public static void chercher_ingredients(int id_recette)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=master_chef;Trusted_Connection=True;");
            conn.Open();

            SqlCommand liste_ingredients_commande = conn.CreateCommand();
            liste_ingredients_commande.CommandText = "SELECT id_ingredient FROM Composition WHERE id_recette ="+ id_recette;
            SqlDataReader liste_ingredient_reader = liste_ingredients_commande.ExecuteReader();
            int i = 0;
            object[] liste_ingredient = new object[100];

            while (liste_ingredient_reader.Read())
            {
                liste_ingredient[i] = liste_ingredient_reader["id_ingredient"];
                i++;
            }

            foreach(liste_ingredient as ingredient)
            {
                SqlCommand decrementer_ingredient = conn.CreateCommand();
                decrementer_ingredient.CommandText = "UPDATE Ingredients SET quantite=quantite-1 WHERE id="+ingredient;

                decrementer_ingredient.ExecuteNonQuery();
            }
        }

        public static void apporter_plat()
        {
            
        }
    }
}
