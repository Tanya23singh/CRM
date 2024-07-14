using CRM_Web_Api.DAL.DAL_Campaign_Repo;
using CRM_Web_Api.DTO.CampaignManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers.Campaign_Management
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly Campaign _common;
        public CampaignController(Campaign common)
        {
            _common = common;
        }
        [HttpPost]
        public IActionResult Insert([FromBody] DTO_Campaign i)
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
        public IActionResult Get([FromBody] DTO_Campaign i)
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
