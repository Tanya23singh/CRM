using CRM_Web_Api.DTO;

namespace CRM_Web_Api.Models
{
    public class UserData
    {
       public int user_id { get; set; }
        public int role_id { get; set; }
        public string rolename { get; set; }
        public string? username { get; set; }

        public string? password { get; set; }

        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public bool active { get; set; }

        public logindto Converttodto()
        {
            logindto lg = new logindto();
            lg.username = username;
            lg.password = password;
            return lg;
        }


     
    }
}
