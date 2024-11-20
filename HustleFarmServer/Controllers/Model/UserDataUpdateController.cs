using Google.Cloud.Firestore;
using HustleFarmServer.Controllers.Model.UserDataForm;
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

   

}
