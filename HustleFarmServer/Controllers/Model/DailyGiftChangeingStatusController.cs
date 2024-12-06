using HustleFarmServer.Controllers.Model.DailyGift;
using HustleFarmServer.Controllers.Model.UserDataForm;
using Microsoft.AspNetCore.Mvc;

namespace HustleFarmServer.Controllers.Model
{

    [ApiController]
    [Route("[controller]")]
    public class DailyGiftChangeingStatusController : ControllerBase
    {
        [HttpPost]
        public IActionResult ChangeReceivedStatusOfUser([FromBody] UserDailyGiftStatus userDailyGiftStatus)
        {
            DailyGiftController.Instance.ChangeDailyGiftReceivedStatus(userDailyGiftStatus.UserId, userDailyGiftStatus.IsReceived);

            return NoContent();
        }
    }
}
