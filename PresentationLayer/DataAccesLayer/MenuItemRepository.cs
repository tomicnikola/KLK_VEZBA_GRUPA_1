using DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class MenuItemRepository
    {
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> mi = new List<MenuItem>();

            using (SqlConnection con = new SqlConnection(Constants.conString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM MenuItems";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while(dr.Read())
                {
                    MenuItem item = new MenuItem();
                    item.Id = dr.GetInt32(0);
                    item.Title = dr.GetString(1);
                    item.Description = dr.GetString(2);
                    item.Price = Convert.ToDecimal(dr.GetDecimal(3));

                    mi.Add(item);

                }

                return mi;
        
            }
        }

        public int InsertMenuItem(MenuItem mi)
        {
            int result;
            using (SqlConnection con = new SqlConnection(Constants.conString))
            {
                string commandText = string.Format("INSERT INTO MenuItems VALUES( '{0}', '{1}', {2})",mi.Title, mi.Description, mi.Price); 
                SqlCommand com = new SqlCommand(commandText, con);

                con.Open();
                result = com.ExecuteNonQuery();
            }

            return result;
        }


        public int UpdateMenuItem(MenuItem mi)
        {
            int result;
            using(SqlConnection con = new SqlConnection(Constants.conString))
            {
                string commandText = string.Format("UPDATE MenuItems SET Title = '{0}' , Description = '{1}', Price = {2}" +
                    "WHERE Id = {3}", mi.Title, mi.Description, mi.Price, mi.Id);
                SqlCommand com = new SqlCommand(commandText, con);

                con.Open();
                result = com.ExecuteNonQuery();
            }

            return result;
        }
    }
}
