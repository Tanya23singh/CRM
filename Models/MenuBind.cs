namespace CRM_Web_Api.Models
{
    public class MenuBind
    {
           public int module_id    {get;set;}
           public int component_id {get;set;}

         public string module_name {get;set;}
        public string component_name {get;set;}

           public bool _add        {get;set;}
           public bool _update     {get;set;}
           public bool _delete     {get;set;}
           public bool _view { get; set; }
        public string routes { get;set;}

        
    }
}
