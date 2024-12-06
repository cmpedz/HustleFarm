using HustleFarmServer.Controllers.Model.UserDataForm;
using Microsoft.AspNetCore.Mvc;

namespace HustleFarmServer.Controllers.Model.DailyGift
{
    [ApiController]
    [Route("[controller]")]
    public class DailyGiftGettingStatusController : ControllerBase
    {
        [HttpPost]
        public IActionResult CheckIsPlayerReceivedDailyGift([FromBody] IntitialUserInfors user)
        {
            bool isReceived = DailyGiftController.Instance.IsUserReceivedDailyGifts(user.UserId).Result;

            if (isReceived)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }

        }

        
    }
}


