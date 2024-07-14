using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.Models;
using System.Data.SqlClient;
using CRM_Web_Api.Services;

namespace CRM_Web_Api.DAL
{
    public class Menu_repo
    {
        private readonly string _connectionstring;
        public Menu_repo(string connectionString)
        {
            _connectionstring = connectionString;
        }
        public List<UserRole> GetUserrole(UserRole i)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@role_id", i.role_id);

            //cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);

            List<UserRole> data = new List<UserRole>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("Userrolesproc", cmd);
                while (reader.Read())
                {
                    UserRole ud = new UserRole
                    {
                        role_id = reader.GetInt32(reader.GetOrdinal("role_id")),
                        user_role = reader.GetString(reader.GetOrdinal("user_role")),
                   
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

        public List<MenuBind> GetComp_Permission(MenuBind m)
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@user_id", Shared_service.userid);
            cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);
            cmd.Parameters.AddWithValue("@routes", m.routes);


            List<MenuBind> data = new List<MenuBind>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("MenuBind", cmd);
                while (reader.Read())
                {
                    MenuBind ud = new MenuBind
                    {
                        module_id = reader.GetInt32(reader.GetOrdinal("module_id")),
                        component_id = reader.GetInt32(reader.GetOrdinal("component_id")),
                        module_name = reader.GetString(reader.GetOrdinal("module_name")),
                        component_name = reader.GetString(reader.GetOrdinal("component_name")),
                        routes = reader.GetString(reader.GetOrdinal("routes")),


                        _add = reader.GetBoolean(reader.GetOrdinal("_add")),
                        _update = reader.GetBoolean(reader.GetOrdinal("_update")),
                        _delete = reader.GetBoolean(reader.GetOrdinal("_delete")),

                        _view = reader.GetBoolean(reader.GetOrdinal("_view")),




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

        public List<MenuBind> GetMenuPermission()
        {
            SqlCommand cmd = new SqlCommand();
            adofunc a = new adofunc(_connectionstring);
            cmd.Parameters.AddWithValue("@user_id", Shared_service.userid);
            cmd.Parameters.AddWithValue("@user_role", Shared_service.userrole);
            cmd.Parameters.AddWithValue("@routes", "");

            List<MenuBind> data = new List<MenuBind>();
            try
            {
                SqlDataReader reader = a.ExecuteReader("MenuBind", cmd);
                while (reader.Read())
                {
                    MenuBind ud = new MenuBind
                    {
                        module_id = reader.GetInt32(reader.GetOrdinal("module_id")),
                        component_id = reader.GetInt32(reader.GetOrdinal("component_id")),
                        module_name = reader.GetString(reader.GetOrdinal("module_name")),
                        component_name= reader.GetString(reader.GetOrdinal("component_name")),
                        routes = reader.GetString(reader.GetOrdinal("routes")),


                        _add = reader.GetBoolean(reader.GetOrdinal("_add")),
                        _update = reader.GetBoolean(reader.GetOrdinal("_update")),
                        _delete = reader.GetBoolean(reader.GetOrdinal("_delete")),

                        _view = reader.GetBoolean(reader.GetOrdinal("_view")),




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
    }
}
