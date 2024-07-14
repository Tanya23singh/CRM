using CRM_Web_Api.Models;

namespace CRM_Web_Api.DTO.DTO_User
{
    public class DTO_User

    {
        public int user_id { get; set; }

        public int role_id { get; set; }
        public string? username { get; set; }

        public string? password { get; set; }

        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public bool active { get; set; }
        public string? choice { get; set; }

        public UserData Converttomodel()
        {
            UserData ud = new UserData();
            ud.role_id = role_id;
            ud.username = username; 
            ud.password = password;
            ud.name = name;
            ud.email = email;
            ud.phone = phone;
            ud.active = active;
            return ud;
        }

    }
}
