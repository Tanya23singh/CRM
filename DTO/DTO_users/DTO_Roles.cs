using CRM_Web_Api.Models.MOD_users;

namespace CRM_Web_Api.DTO.DTO_users
{
    public class DTO_Roles
    {
        public string RoleName { get; set; }
        public int roleid { get; set; }
        public string choice{ get; set; }
        public MOD_Roles converttomodel()
        {
            MOD_Roles mb = new MOD_Roles();
            mb.RoleName = RoleName;
            mb.roleid = roleid;
            return mb;
        }
    }
}
