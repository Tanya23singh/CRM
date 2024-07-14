using CRM_Web_Api.Models.OpportunityManagement;
using CRM_Web_Api.ConnectionFunctions;
using System.Data.SqlClient;
using CRM_Web_Api.Models;

namespace CRM_Web_Api.DAL.DAL_Opportunity_Repo
{
    public class Opportunity
    {
        private readonly string _connectionstring;
        public Opportunity(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<Dropdown> Dropdownbind()
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@const_var", 2);


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
        public List<MOD_Opportunity> GetDetail(MOD_Opportunity i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "GET");


            List<MOD_Opportunity> data = new List<MOD_Opportunity>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Opportunity_Proc", cmd);
                while (reader.Read())
                {
                    MOD_Opportunity ud = new MOD_Opportunity
                    {
                        OpportunityID = reader.GetInt32(reader.GetOrdinal("OpportunityID")),
                        OpportunityName = reader.GetString(reader.GetOrdinal("OpportunityName")),
                        AccountID = reader.GetInt32(reader.GetOrdinal("AccountID")),
                        Stage = reader.GetString(reader.GetOrdinal("Stage")),
                        Probability = reader.GetString(reader.GetOrdinal("Probability")),
                        ExpectedCloseDate = reader.GetDateTime(reader.GetOrdinal("ExpectedCloseDate")).ToString("yyyy-MM-dd")




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
        public int InsertData(MOD_Opportunity opportunity, string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
         cmd.Parameters.AddWithValue("@OpportunityID", opportunity.OpportunityID);
cmd.Parameters.AddWithValue("@OpportunityName", opportunity.OpportunityName);
cmd.Parameters.AddWithValue("@AccountID", opportunity.AccountID);
cmd.Parameters.AddWithValue("@Stage", opportunity.Stage);
cmd.Parameters.AddWithValue("@Probability", opportunity.Probability);
cmd.Parameters.AddWithValue("@ExpectedCloseDate", opportunity.ExpectedCloseDate);
            cmd.Parameters.AddWithValue("@action", choice);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows = a.ExecuteNonQuery("Opportunity_Proc", cmd);

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
