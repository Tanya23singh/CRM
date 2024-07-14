using CRM_Web_Api.Models;

namespace CRM_Web_Api.DTO
{
    public class DTO_GetPermissions

    {
     public string routes { get; set; }

        public MenuBind Converttomodel()
        {
            MenuBind mb = new MenuBind();
            mb.routes = routes;
            return mb;
        }

        

      
    }
}
