using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.Models;
using CRM_Web_Api.Models.MOD_users;
using System.Data.SqlClient;

namespace CRM_Web_Api.DAL.DAL_User_Repo
{
    public class DAL_Roles
    {
        private readonly string _connectionstring;
        public DAL_Roles(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<UserData> GetUserDetail(UserData i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "GetUserData");


            List<UserData> data = new List<UserData>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Userdetail_Proc", cmd);
                while (reader.Read())
                {
                    UserData ud = new UserData
                    {
                        role_id = reader.GetInt32(reader.GetOrdinal("role_id")),
                        name = reader.GetString(reader.GetOrdinal("name")),
                        username= reader.GetString(reader.GetOrdinal("username")),
                        rolename= reader.GetString(reader.GetOrdinal("rolename")),
                        phone = reader.GetString(reader.GetOrdinal("phone")),
                        user_id = reader.GetInt32(reader.GetOrdinal("user_id")),

                        active = reader.GetBoolean(reader.GetOrdinal("active")),
                        email= reader.GetString(reader.GetOrdinal("email")),
                        



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
        public List<Dropdown> Dropdownbind()
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@const_var",1);

            
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
        public int InsertUserData(UserData i,string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@role_id", i.role_id);
            cmd.Parameters.AddWithValue("@name", i.name);
            cmd.Parameters.AddWithValue("@username", i.username);
            cmd.Parameters.AddWithValue("@email", i.email);
            cmd.Parameters.AddWithValue("@phone", i.phone); 
            cmd.Parameters.AddWithValue("@active", i.active);
            cmd.Parameters.AddWithValue("@password", i.password);
            cmd.Parameters.AddWithValue("@action", choice);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows= a.ExecuteNonQuery("Userdetail_Proc", cmd);

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
        public int InsertRolesData(MOD_Roles i, string choice)
            {
                int rows = 0;
                SqlCommand cmd = new SqlCommand();
                adofunc a = new adofunc(_connectionstring);
                cmd.Parameters.AddWithValue("@rolename", i.RoleName);
                cmd.Parameters.AddWithValue("@choice", choice);
                cmd.Parameters.AddWithValue("@roleid", i.roleid);

                //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

                //List<MOD_Roles> data = new List<MOD_Roles>();
                try
                {
                    rows = a.ExecuteNonQuery("ROLES_GET_INST", cmd);

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
