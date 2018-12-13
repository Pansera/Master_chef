using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public class InitBDD
    {
        public static void InitializeDatabase()
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=master_chef;Trusted_Connection=True;");
            conn.Open();

            SqlCommand reset_quantite = conn.CreateCommand();
            reset_quantite.CommandText = "UPDATE Ingredients SET quantite=50";
            reset_quantite.ExecuteNonQuery();

            SqlCommand reset_dispo = conn.CreateCommand();
            reset_dispo.CommandText = "UPDATE Recettes SET disponible=1";
            reset_dispo.ExecuteNonQuery();

            SqlCommand reset_date = conn.CreateCommand();
            reset_date.CommandText = "UPDATE Ingredients SET date=GETDATE()";
            reset_date.ExecuteNonQuery();
        }
    }
}
