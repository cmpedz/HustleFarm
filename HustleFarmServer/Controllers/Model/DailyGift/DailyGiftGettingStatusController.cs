using HustleFarmServer.Controllers.Model.UserDataForm;
using Microsoft.AspNetCore.Mvc;

namespace HustleFarmServer.Controllers.Model.DailyGift
{
    [ApiController]
    [Route("[controller]")]
    public class DailyGiftGettingStatusController : ControllerBase
    {
        [HttpPost]
        public IActionResult CheckIsPlayerReceivedDailyGift([FromBody] string userId)
        {
            bool isReceived = DailyGiftController.Instance.IsUserReceivedDailyGifts(userId).Result;

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


