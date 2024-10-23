using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text.Json;



namespace HustleFarmServer.Controllers.Model
{
    [ApiController]

    [Route("[controller]")]

    public class GachaServerController : ControllerBase
    {

        public GachaServerController()
        {
        }
        [HttpGet]
        public IActionResult GiveGachaItemToClientsSide()
        {

            return Ok();
        }

    }
}
