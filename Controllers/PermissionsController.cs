using CRM_Web_Api.DAL;
using CRM_Web_Api.DTO.Permissions;
using CRM_Web_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly Permissions_repo _common;
        public PermissionsController(Permissions_repo common)
        {
            _common = common;
        }
        [HttpPost]

        public IActionResult Dropdown()
        {
            List<Dropdown> role = _common.Dropdownbind(1);
            List<Dropdown> user= _common.Dropdownbind(3);
            List<Dropdown> module= _common.Dropdownbind(5);
            List<Dropdown> component= _common.Dropdownbind(6);

            var dropdowns = new
            {
                role = role,
                user = user,
                module = module,
                component = component
            };

            return Ok(dropdowns);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] DTO_permissions i)
        {
            var ud = _common.InsertDetail(i.converttomodel(), i.choice);
            if (ud > 0)
            {
                return Ok(1);
            }
            else
            {
                return Ok(0);
            }
        }
        [HttpPost]
        public IActionResult Get([FromBody] DTO_permissions i)
        {
            var ud = _common.GetDetail(i.converttomodel());
            return Ok(ud);
        }
        //[HttpGet]
        //public IActionResult GetMenu()
        //{
        //    var ud = _menu.GetMenuPermission();

        //    return Ok(ud);
        //}
    }
}
