using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRM_Web_Api.DAL;
using CRM_Web_Api.DTO;

namespace CRM_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly Menu_repo _menu;
       


        public MenuController(Menu_repo menu)
        {
            _menu = menu;
        }

        [HttpGet]
        public IActionResult GetMenu()
        {
            var ud = _menu.GetMenuPermission();

            return Ok(ud);
        }
        [HttpPost]
        public IActionResult GetPermissions([FromBody] DTO_GetPermissions i)
        {
            var ud = _menu.GetComp_Permission(i.Converttomodel());

            return Ok(ud);
        }
        [HttpPost]
        public IActionResult GetRole([FromBody] DTO_UserRole i)
        {
            var ud = _menu.GetUserrole(i.Converttomodel());

            return Ok(ud);
        }
    }
}
