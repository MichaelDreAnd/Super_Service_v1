using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Service.Models
{
    public class DB
    {
        static string connString = "Data Source=.; Initial Catalog=SuperServiceDB; Integrated Security=True";

        // Author Nicklas HJ
        public static List<Company> GetCompanies(int ZipCode, string Address)
        {
            List<Company> Companies = new List<Company>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company WHERE ZipCode like @ZipCode AND Address like @Address", conn);
                cmd.Parameters.AddWithValue("@ZipCode", ZipCode + "%");
                cmd.Parameters.AddWithValue("@Address", Address + "%");
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Company Company = new Company(Convert.ToString((reader[1])), Convert.ToString(reader[2]), Convert.ToInt32(reader[3]));
                        Companies.Add(Company);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return Companies;
        }
    }
}