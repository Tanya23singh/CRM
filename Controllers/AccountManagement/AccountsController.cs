using CRM_Web_Api.DAL.DAL_Account_Repo;
using CRM_Web_Api.DTO.AccountManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers.AccountManagement
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly Account _common;
        public AccountsController(Account common)
        {
            _common=common;
        }
        [HttpPost]
        public IActionResult Insert([FromBody] DTO_Account i)
        {
            var ud = _common.InsertContactData(i.converttomodel(), i.choice);
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
        public IActionResult Get([FromBody] DTO_Account i)
        {
            var ud = _common.GetAccountDetail(i.converttomodel());
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
