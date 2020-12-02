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
                string commandText = "Insert Into MenuItems(Title, Description, Price) VALUE(@Title, @Description, @Price)";
                SqlCommand com = new SqlCommand(commandText, con);
                com.Parameters.AddWithValue("@Title", mi.Title);
                com.Parameters.AddWithValue("@Description", mi.Description);
                com.Parameters.AddWithValue("@Price", mi.Price);

                result = com.ExecuteNonQuery();
            }

            return result;
        }
    }
}
