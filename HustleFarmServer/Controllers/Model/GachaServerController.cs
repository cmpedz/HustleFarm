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
        private ItemsGachaStorage itemsGachaStorage = ItemsGachaStorage.GetInstance();
        public GachaServerController()
        {

         
        }
        [HttpGet]
        public IActionResult GiveGachaItemToClientsSide()
        {

            Dictionary<string, int[]> itemsGachaTypeRange = ItemsGachaRateManager.GetInstance().ItemsGachaTypeRange;

            ItemGachaStorageManager.GetInstance().GetItemsGachaFromFireBaseAsync().Wait();

            return Ok(JsonSerializer.Serialize(itemsGachaTypeRange, new JsonSerializerOptions()));
        }



    }
}
