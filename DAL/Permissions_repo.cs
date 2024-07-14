using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.Models;
using CRM_Web_Api.Models.Permissions;
using System.Data.SqlClient;

namespace CRM_Web_Api.DAL
{
    public class Permissions_repo
    {
        private readonly string _connectionstring;
        public Permissions_repo(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<Dropdown> Dropdownbind(int constVar)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@const_var", constVar);

            List<Dropdown> data = new List<Dropdown>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Dropdowns", cmd);
                while (reader.Read())
                {
                    Dropdown ud = new Dropdown
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        description = reader.GetString(reader.GetOrdinal("description"))
                    };
                    data.Add(ud);
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception or handling it appropriately.
                throw;
            }
            return data;
        }

        public List<MOD_Permissions> GetDetail(MOD_Permissions i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@action", "GET");


            List<MOD_Permissions> data = new List<MOD_Permissions>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Permissions_PROC", cmd);
                while (reader.Read())
                {
                    MOD_Permissions ud = new MOD_Permissions
                    {
                        permission_id = reader.GetInt32(reader.GetOrdinal("permission_id")),
                        module_id = reader.GetInt32(reader.GetOrdinal("module_id")),
                        component_id = reader.GetInt32(reader.GetOrdinal("component_id")),
                        _add = reader.GetBoolean(reader.GetOrdinal("_add")),
                        _update = reader.GetBoolean(reader.GetOrdinal("_update")),
                        _delete = reader.GetBoolean(reader.GetOrdinal("_delete")),
                        _view = reader.GetBoolean(reader.GetOrdinal("_view")),
                        user_role = reader.GetInt32(reader.GetOrdinal("user_role")),
                        user_id = reader.GetInt32(reader.GetOrdinal("user_id")),
                        module_name = reader.GetString(reader.GetOrdinal("module_name")),
                        component_name= reader.GetString(reader.GetOrdinal("component_name")),
                        role_name= reader.GetString(reader.GetOrdinal("role_name")),
                        username= reader.GetString(reader.GetOrdinal("username"))



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
        public int InsertDetail(MOD_Permissions sales, string choice)
        {
            int rows = 0;
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@permission_id", sales.permission_id);
            cmd.Parameters.AddWithValue("@module_id", sales.module_id);
            cmd.Parameters.AddWithValue("@component_id", sales.component_id);
            cmd.Parameters.AddWithValue("@_add", sales._add);
            cmd.Parameters.AddWithValue("@_update", sales._update);
            cmd.Parameters.AddWithValue("@_view", sales._view);
            cmd.Parameters.AddWithValue("@_delete", sales._delete);
            cmd.Parameters.AddWithValue("@user_role", sales.user_role);
            cmd.Parameters.AddWithValue("@user_id", sales.user_id);
            cmd.Parameters.AddWithValue("@action", choice);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            //List<MOD_Roles> data = new List<MOD_Roles>();
            try
            {
                rows = a.ExecuteNonQuery("Permissions_PROC", cmd);

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
