using CRM_Web_Api.Models.Permissions;

namespace CRM_Web_Api.DTO.Permissions
{
    public class DTO_permissions
    {
        public int permission_id { get; set; }
        public int module_id { get; set; }
        public int component_id { get; set; }
        public bool _add { get; set; }
        public bool _update { get; set; }
        public bool _delete { get; set; }
        public bool _view { get; set; }
        public int user_role { get; set; }
        public int user_id { get; set; }
        public string choice { get; set; }


        public MOD_Permissions converttomodel()
        {
            MOD_Permissions ms = new MOD_Permissions();
            ms.permission_id = permission_id;
            ms.module_id = module_id;
            ms.component_id = component_id;
            ms._add = _add;
            ms._update= _update;
            ms._delete = _delete;
            ms._view = _view;
            ms.user_id=user_id;
            ms.user_role = user_role;


            return ms;

        }
    }
}
