using CRM_Web_Api.DTO;

namespace CRM_Web_Api.Models
{
    public class UserRole
    {
        public int role_id { get; set; }
        public string user_role { get; set; }
        public DTO_UserRole Converttodto()
        {
            DTO_UserRole lg = new DTO_UserRole();
lg.role_id = role_id;
            return lg;
        }


    }
}
