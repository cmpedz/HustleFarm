using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HustleFarmServer.Controllers.Model
{

    [ApiController]

    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private UserAccountManager _userAccountManager = new UserAccountManager();
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
                    userDataToJson = _userAccountManager.CreateAccount(user.UserId).Result;

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
