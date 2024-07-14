namespace CRM_Web_Api.Models.Permissions
{
    public class MOD_Permissions
    {
  
        public int permission_id{ get; set; }
        public int module_id { get; set; }
        public int component_id { get; set; }
        public bool _add { get; set; }
        public bool _update{ get; set; }
        public bool _delete { get; set; }
        public bool _view { get; set; }
        public int user_role { get; set; }
        public int user_id { get; set; }

        public string? module_name { get; set; }

        public string? component_name { get; set; }

        public string? role_name { get; set; }

        public string? username { get; set; }
    }
}
