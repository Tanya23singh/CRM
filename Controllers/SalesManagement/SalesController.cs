using CRM_Web_Api.DAL.DAL_Sales_repo;
using CRM_Web_Api.DTO.SalesManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers.SalesManagement
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly Sales _common;
        public SalesController(Sales common)
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
    public IActionResult Insert([FromBody] DTO_Sales i)
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
    public IActionResult Get([FromBody] DTO_Sales i)
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
