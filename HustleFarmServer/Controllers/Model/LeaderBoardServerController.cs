using Google.Cloud.Firestore;
using HustleFarmServer.Controllers.Model.UserDataForm;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HustleFarmServer.Controllers.Model
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderBoardServerController : ControllerBase
    {
        [HttpPost]
        public IActionResult IncreaseUserPoint([FromBody] UserPointData userPointData)
        {

            LeaderBoardDataController.Instance.IncreaseUserPoint(userPointData.Id, (float)Math.Round(userPointData.Point, 2));

            return Ok(LeaderBoardDataController.Instance.GetSortedHighestUsers().Result);


        }

        [HttpGet]
        public IActionResult GetLeaderBoard()
        {
            return Ok(LeaderBoardDataController.Instance.GetSortedHighestUsers().Result);
        }
    }


}
