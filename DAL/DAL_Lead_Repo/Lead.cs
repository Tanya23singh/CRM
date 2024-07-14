using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.Models;
using CRM_Web_Api.Models.LeadManagement;
using System.Data.SqlClient;
namespace CRM_Web_Api.DAL.DAL_Lead_Repo
{
    public class Lead
    {
        private readonly string _connectionstring;
        public Lead(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<Dropdown> Dropdownbind()
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@const_var", 3);


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
        public List<MOD_Lead> GetDetail(MOD_Lead i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "GET");


            List<MOD_Lead> data = new List<MOD_Lead>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Leads_Proc", cmd);
                while (reader.Read())
                {
                    MOD_Lead ud = new MOD_Lead
                    {
                        LeadID = reader.GetInt32(reader.GetOrdinal("LeadID")),
                        FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                        LastName = reader.GetString(reader.GetOrdinal("LastName")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                        Company = reader.GetString(reader.GetOrdinal("Company")),
                        Status = reader.GetString(reader.GetOrdinal("Status")),
                        Source = reader.GetString(reader.GetOrdinal("Source")),
                        AssignedTo = reader.GetInt32(reader.GetOrdinal("AssignedTo"))




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
        public int InsertData(MOD_Lead i, string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@LeadID", i.LeadID);
            cmd.Parameters.AddWithValue("@FirstName", i.FirstName);
            cmd.Parameters.AddWithValue("@LastName", i.LastName);
            cmd.Parameters.AddWithValue("@Email", i.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", i.PhoneNumber);
            cmd.Parameters.AddWithValue("@Company", i.Company);
            cmd.Parameters.AddWithValue("@Status", i.Status);
            cmd.Parameters.AddWithValue("@Source", i.Source);
            cmd.Parameters.AddWithValue("@AssignedTo", i.AssignedTo);
            cmd.Parameters.AddWithValue("@action", choice);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows = a.ExecuteNonQuery("Leads_Proc", cmd);

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
