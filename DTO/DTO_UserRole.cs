using CRM_Web_Api.Models;

namespace CRM_Web_Api.DTO
{
    public class DTO_UserRole
    {
        public int role_id { get; set; }
        public UserRole Converttomodel()
        {
            UserRole lg = new UserRole();
            lg.role_id = role_id;
            return lg;
        }
    }
}
