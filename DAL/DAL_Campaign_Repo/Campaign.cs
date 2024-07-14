using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.Models.MarketingCampaignManagement;
using System.Data.SqlClient;
namespace CRM_Web_Api.DAL.DAL_Campaign_Repo

{
    public class Campaign
    {
        private readonly string _connectionstring;
        public Campaign(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<MOD_Campaign> GetDetail(MOD_Campaign i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "GetUserData");


            List<MOD_Campaign> data = new List<MOD_Campaign>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Campaign_Proc", cmd);
                while (reader.Read())
                {
                    MOD_Campaign ud = new MOD_Campaign
                    {
                        CampaignID = reader.GetInt32(reader.GetOrdinal("CampaignID")),
                        CampaignName = reader.GetString(reader.GetOrdinal("CampaignName")),
                        Type = reader.GetString(reader.GetOrdinal("Type")),
                        StartDate = reader.GetString(reader.GetOrdinal("StartDate")), 
                        EndDate = reader.GetString(reader.GetOrdinal("EndDate")) ,
                        Budget = reader.GetString(reader.GetOrdinal("Budget"))




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
        public int InsertData(MOD_Campaign i, string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", choice);
            cmd.Parameters.AddWithValue("@CampaignID", i.CampaignID);
            cmd.Parameters.AddWithValue("@CampaignName", i.CampaignName);
            cmd.Parameters.AddWithValue("@Type", i.Type );
            cmd.Parameters.AddWithValue("@StartDate", i.StartDate );
            cmd.Parameters.AddWithValue("@EndDate", i.EndDate );
            cmd.Parameters.AddWithValue("@Budget", i.Budget);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows = a.ExecuteNonQuery("Campaign_Proc", cmd);

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
