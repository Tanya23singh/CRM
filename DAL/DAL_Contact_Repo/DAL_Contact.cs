using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.Models;
using CRM_Web_Api.Models.ContactManagement;
using System.Data.SqlClient;

namespace CRM_Web_Api.DAL.DAL_Contact_Repo
{
    public class DAL_Contact
    {
        private readonly string _connectionstring;
        public DAL_Contact (string connectionString)
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
        public List<MOD_Contact> GetDetail(MOD_Contact i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "GET");


            List<MOD_Contact> data = new List<MOD_Contact>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Contacts_Proc", cmd);
                while (reader.Read())
                {
                    MOD_Contact ud = new MOD_Contact
                    {
                        ContactID = reader.GetInt32(reader.GetOrdinal("ContactID")),
                        FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                        LastName = reader.GetString(reader.GetOrdinal("LastName")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                        Address = reader.GetString(reader.GetOrdinal("Address")),
                        City = reader.GetString(reader.GetOrdinal("City")),
                        State = reader.GetString(reader.GetOrdinal("State")),
                        PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                        Country = reader.GetString(reader.GetOrdinal("Country")),
                        Notes = reader.GetString(reader.GetOrdinal("Notes")),
                        AccountID = reader.GetInt32(reader.GetOrdinal("AccountID"))




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
        public int InsertData(MOD_Contact i, string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@ContactID", i.ContactID);
            cmd.Parameters.AddWithValue("@FirstName", i.FirstName);
            cmd.Parameters.AddWithValue("@LastName", i.LastName);
            cmd.Parameters.AddWithValue("@Email", i.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", i.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address", i.Address);
            cmd.Parameters.AddWithValue("@City", i.City);
            cmd.Parameters.AddWithValue("@State", i.State);
            cmd.Parameters.AddWithValue("@PostalCode", i.PostalCode);
            cmd.Parameters.AddWithValue("@Country", i.Country);
            cmd.Parameters.AddWithValue("@Notes", i.Notes);
            cmd.Parameters.AddWithValue("@AccountID", i.AccountID);
            cmd.Parameters.AddWithValue("@action", choice);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows = a.ExecuteNonQuery("Contacts_Proc", cmd);

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
