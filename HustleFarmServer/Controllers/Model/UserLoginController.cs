using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

                    var data = new
                    {
                        UserBag = new
                        {
                            Items = new List<string> {
                            KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Seed_Crop),

                            KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Food_Crop)
                            }
                        }
                        ,
                        UserInfors = new { test = "Test update data"}
                    };

                    _userAccountManager.UpdateUsersDataToServer(JsonConvert.SerializeObject(data)).Wait();

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
