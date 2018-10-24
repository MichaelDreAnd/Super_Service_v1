using System;
using System.Collections.Generic;
using System.Data;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company WHERE ZipCode like @ZipCode OR Address like @Address", conn);
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

        internal static void PostCompany(string name, string address, int zipCode, string city)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Company (CompanyName, Address, [ZipCode]) VALUES (@CompanyName, @Address, @ZipCode)", conn);
                    cmd.Parameters.Add(CreateParam("@CompanyName", name));
                    cmd.Parameters.Add(CreateParam("@Address", address));
                    cmd.Parameters.Add(CreateParam("@ZipCode", zipCode));

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        #region CREATEPARAMS
        private static SqlParameter CreateParam(string paramName, string paramValue)
        {//parameter methods which convert the parameter into either varchar or int.
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.VarChar;
            return param;
        }
        private static SqlParameter CreateParam(string paramName, double paramValue)
        {//parameter methods which convert the parameter into either varchar or int.
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.Float;
            return param;
        }

        private static SqlParameter CreateParam(string paramName, int paramValue)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.Int;
            return param;
        }
        private static SqlParameter CreateParam(string paramName, DateTime paramValue)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.DateTime;
            return param;
        }

        #endregion
    }
}