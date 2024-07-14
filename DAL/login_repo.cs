using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.DTO;
using CRM_Web_Api.Models;
using System.Data.SqlClient;

namespace CRM_Web_Api.DAL
{
    public class login_repo
    {
        private readonly string _connectionstring;
        public login_repo(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<UserData> login(UserData lg)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "Getdata");
            cmd.Parameters.AddWithValue("@username", lg.username);
            cmd.Parameters.AddWithValue("@password", lg.password);

            List<UserData> data = new List<UserData>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Userdetail_Proc", cmd);
                while (reader.Read())
                {
                    UserData ud = new UserData
                    {
                        user_id = reader.GetInt32(reader.GetOrdinal("user_id")),
                        role_id = reader.GetInt32(reader.GetOrdinal("role_id")),

                        username = reader.GetString(reader.GetOrdinal("username")),
                        name = reader.GetString(reader.GetOrdinal("name")),

                        email = reader.GetString(reader.GetOrdinal("email")),
                                 phone = reader.GetString(reader.GetOrdinal("phone")),
                        active = reader.GetBoolean(reader.GetOrdinal("active"))

                    };
                    data.Add(ud);

                }
            }
            catch (Exception ex)
            {
                
                throw ; 
            }
            return data;

        }
    }
}
