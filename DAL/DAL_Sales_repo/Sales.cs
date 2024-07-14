using CRM_Web_Api.Models.SalesManagement;
using CRM_Web_Api.ConnectionFunctions;
using System.Data.SqlClient;
using CRM_Web_Api.Models;

namespace CRM_Web_Api.DAL.DAL_Sales_repo
{
    public class Sales
    {
        private readonly string _connectionstring;
        public Sales(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<Dropdown> Dropdownbind()
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@const_var", 4);


            List<Dropdown> data = new List<Dropdown>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Dropdowns", cmd);
                while (reader.Read())
                {
                    Dropdown ud = new Dropdown
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        description = reader.GetString(reader.GetOrdinal("description")),
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
        public List<MOD_Sales> GetDetail(MOD_Sales i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "GET");


            List<MOD_Sales> data = new List<MOD_Sales>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Sales_Proc", cmd);
                while (reader.Read())
                {
                    MOD_Sales ud = new MOD_Sales
                    {
                        SalesID = reader.GetInt32(reader.GetOrdinal("SaleID")),
                        OpportunityID = reader.GetInt32(reader.GetOrdinal("OpportunityID")),
                        Amount =  reader.GetString(reader.GetOrdinal("Amount")),
                                                CloseDate = reader.GetDateTime(reader.GetOrdinal("CloseDate")).ToString("yyyy-MM-dd")




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
        public int InsertData(MOD_Sales sales, string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@SalesID", sales.SalesID);
            cmd.Parameters.AddWithValue("@OpportunityID", sales.OpportunityID);
            cmd.Parameters.AddWithValue("@Amount", sales.Amount);
            cmd.Parameters.AddWithValue("@CloseDate", sales.CloseDate);
            cmd.Parameters.AddWithValue("@action", choice);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows = a.ExecuteNonQuery("Sales_Proc", cmd);

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
