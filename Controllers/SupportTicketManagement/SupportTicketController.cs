using CRM_Web_Api.DAL.DAL_SupportTicket_Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers.SupportTicketManagement
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        private readonly SupportTicket _common;
        public SupportTicketController(SupportTicket common)
        {
            _common = common;
        }

        //[HttpGet]
        //public IActionResult GetMenu()
        //{
        //    var ud = _menu.GetMenuPermission();

        //    return Ok(ud);
        //}
    }
}
