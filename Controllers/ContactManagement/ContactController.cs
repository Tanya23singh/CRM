using CRM_Web_Api.DAL.DAL_Contact_Repo;
using CRM_Web_Api.DTO.ContactManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_Api.Controllers.ContactManagement
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DAL_Contact _call;



        public ContactController(DAL_Contact call)
        {
            _call = call;
        }
        [HttpPost]
        public IActionResult Dropdown()
        {
            var ud = _call.Dropdownbind();
            return Ok(ud);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] DTO_Contact i)
        {
            var ud = _call.InsertData(i.converttomodel(), i.choice);
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
        public IActionResult Get([FromBody] DTO_Contact i)
        {
            var ud = _call.GetDetail(i.converttomodel());
            return Ok(ud);
        }


    }
}
