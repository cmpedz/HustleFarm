using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HustleFarmServer.Controllers.Model
{

    [ApiController]

    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult HandleUserLogin([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("require user id ");
            }
            else
            {
                return Ok(user.UserId);
            }
        }
    }

    public class User
    {
        public string? UserId { get; set; }
    }
}
