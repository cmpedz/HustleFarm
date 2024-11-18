using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HustleFarmServer.Controllers.Model
{
    [ApiController]

    [Route("[controller]")]
    public class UserDataUpdateController : ControllerBase
    {
        private UserAccountManager? _userAccountManager;

        [HttpPost]
        public IActionResult UpdateUserData([FromBody] UserData userData)
        {
            if (userData == null) return NotFound();

            if (userData.UserId != null)
            {
                _userAccountManager = new UserAccountManager(userData.UserId);

                _userAccountManager.UpdateUsersDataToServer(JsonConvert.SerializeObject(userData)).Wait();
            }

            return NoContent();
        }
    }

    public class UserData {

        public string? UserId { get; set; }

        public UserBag? UserBag { get; set; }

        public UserInfors? UserInfors { get; set; }
    }

    public class UserBag
    {
        public List<string>? Items { get; set; }
    }

    public class UserInfors
    {
        public string? Name { get; set; }
    }


}
