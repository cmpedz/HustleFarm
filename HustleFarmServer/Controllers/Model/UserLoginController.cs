using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HustleFarmServer.Controllers.Model
{

    [ApiController]

    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private UserAccountManager _userAccountManager;
        [HttpPost]
        public IActionResult HandleUserLogin([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("require user id ");
            }
            else
            {
                string userDataToJson = "Hello World";

                if(user.UserId != null)
                {

                    _userAccountManager = new UserAccountManager(user.UserId);

                    userDataToJson = _userAccountManager.CreateAccount().Result;

                }
                
                

                return Ok(userDataToJson);
            }
        }
    }

    public class User
    {
        public string? UserId { get; set; }
    }
}
