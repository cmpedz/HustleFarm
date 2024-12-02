using HustleFarmServer.Controllers.Model.UserDataForm;
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
        public IActionResult HandleUserLogin([FromBody] IntitialUserInfors user)
        {
            if (user == null)
            {
                return BadRequest("require user id ");
            }
            else
            {
                string userDataToJson = "Hello World";

                if(user != null && user.UserId != null)
                {

                    _userAccountManager = new UserAccountManager(user.UserId);

                    userDataToJson = _userAccountManager.CreateAccount(user).Result;

                }
                
                

                return Ok(userDataToJson);
            }
        }
    }


}
