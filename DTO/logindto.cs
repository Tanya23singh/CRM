using CRM_Web_Api.Models;

namespace CRM_Web_Api.DTO
{
    public class logindto
    {

        public string? username { get; set; }
        public string? password { get; set; }

        public UserData Converttomodel()
        {
            UserData lg = new UserData();
            lg.username = username;
            lg.password = password;
            return lg;
        }
    }

}
