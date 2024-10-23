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

        private Dictionary<string, int[]> itemsGachaTypeRange = [];
        public GachaServerController()
        {

         
        }
        [HttpGet]
        public IActionResult GiveGachaItemToClientsSide()
        {

            ItemGachaStorageManager.GetInstance().GetItemsGachaFromFireBaseAsync().Wait();

            if (itemsGachaStorage.GachaItemsRate == null) return Ok("error empty dictionary");

            int startBorder = 0;

            int sumQuantitiesCase = 10000;

            foreach (KeyValuePair<string, float> rateOfType in itemsGachaStorage.GachaItemsRate)
            {

                int lastBorder = (int)(rateOfType.Value * sumQuantitiesCase) + startBorder;

                itemsGachaTypeRange.Add(rateOfType.Key, [startBorder, lastBorder]);

                startBorder = lastBorder;
            }


            if (itemsGachaTypeRange.Count == 0) return Ok("error when get data from firebase");

            return Ok(JsonSerializer.Serialize(itemsGachaTypeRange, new JsonSerializerOptions()));
        }



    }
}
