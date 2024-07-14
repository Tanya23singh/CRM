using CRM_Web_Api.DAL.DAL_Lead_Repo;
using CRM_Web_Api.DTO.LeadManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers.LeadManagement
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly Lead _common;
        public LeadController(Lead common)
        {
            _common = common;
        }
        [HttpPost]
        public IActionResult Dropdown()
        {
            var ud = _common.Dropdownbind();
            return Ok(ud);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] DTO_Lead i)
        {
            var ud = _common.InsertData(i.converttomodel(), i.choice);
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
        public IActionResult Get([FromBody] DTO_Lead i)
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
