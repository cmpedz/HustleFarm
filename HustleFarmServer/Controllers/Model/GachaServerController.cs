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

            Dictionary<string, List<object>> itemsGacha = ItemsGachaStorage.GetInstance().GachaItemsDictionary;

            Dictionary<string, List<string>> itemsGachaId = ItemsGachaStorage.GetInstance().CheckItemExistFlag;

            ItemGachaStorageManager.GetInstance().GetItemsGachaFromFireBaseAsync().Wait();

            return Ok(JsonSerializer.Serialize(itemsGachaTypeRange, new JsonSerializerOptions()) + "\n" + 
                    JsonSerializer.Serialize(itemsGacha, new JsonSerializerOptions()) + "\n" +
                    JsonSerializer.Serialize(itemsGachaId, new JsonSerializerOptions())
                );
        }



    }
}
