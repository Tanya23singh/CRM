using CRM_Web_Api.DAL.DAL_User_Repo;
using CRM_Web_Api.DTO.DTO_User;
using CRM_Web_Api.DTO.DTO_users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers.Users
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DAL_Roles _roles;
        public UserController(DAL_Roles role)
        {
            _roles = role;
        }

        [HttpPost]
        public IActionResult InsertRole([FromBody] DTO_Roles i)
        {
            var ud = _roles.InsertRolesData(i.converttomodel(),i.choice);
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
        public IActionResult Dropdown()
        {
            var ud = _roles.Dropdownbind();
            return Ok(ud);
        }
        [HttpPost]
        public IActionResult InsertUser([FromBody] DTO_User i)
        {
            var ud = _roles.InsertUserData(i.Converttomodel(), i.choice);
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
        public IActionResult GetUser([FromBody] DTO_User i)
        {
            var ud = _roles.GetUserDetail(i.Converttomodel());
            return Ok(ud);
        }

    }
}
