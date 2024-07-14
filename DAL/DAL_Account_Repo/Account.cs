using CRM_Web_Api.ConnectionFunctions;
using System.Data.SqlClient;
using CRM_Web_Api.Models.AccountManagement;


namespace CRM_Web_Api.DAL.DAL_Account_Repo
{
    public class Account
    {
        private readonly string _connectionstring;
        public Account(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<MOD_Account> GetAccountDetail(MOD_Account i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@choice", "GET");


            List<MOD_Account> data = new List<MOD_Account>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Accounts_PROC", cmd);
                while (reader.Read())
                {
                    MOD_Account ud = new MOD_Account
                    {
                         AccountID = reader.GetInt32(reader.GetOrdinal("AccountID")),
                        AccountName = reader.GetString(reader.GetOrdinal("AccountName")),
                        Address= reader.GetString(reader.GetOrdinal("Address")),
                        City = reader.GetString(reader.GetOrdinal("City")),
                        Country = reader.GetString(reader.GetOrdinal("Country")),
                        Industry = reader.GetString(reader.GetOrdinal("Industry")),

                        PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                        State = reader.GetString(reader.GetOrdinal("State")),
                        Website = reader.GetString(reader.GetOrdinal("Website")),




                    };
                    data.Add(ud);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return data;

        }
        public int InsertContactData(MOD_Account i, string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@AccountID", i.AccountID);
            cmd.Parameters.AddWithValue("@AccountName", i.AccountName);
            cmd.Parameters.AddWithValue("@Address", i.Address);
            cmd.Parameters.AddWithValue("@City", i.City);
            cmd.Parameters.AddWithValue("@Country", i.Country);
            cmd.Parameters.AddWithValue("@Industry", i.Industry);
            cmd.Parameters.AddWithValue("@PostalCode", i.PostalCode);
            cmd.Parameters.AddWithValue("@State", i.State);
            cmd.Parameters.AddWithValue("@Website", i.Website);
            cmd.Parameters.AddWithValue("@choice", choice);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows = a.ExecuteNonQuery("Accounts_PROC", cmd);

                //SqlDataReader reader = a.ExecuteReader("Userrolesproc", cmd);
                //while (reader.Read())
                //{
                //    MOD_Roles ud = new MOD_Roles
                //    {

                //        user_role = reader.GetString(reader.GetOrdinal("user_role")),

                //    };
                //    data.Add(ud);

                //}
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
            return rows;

        }
    }
}
