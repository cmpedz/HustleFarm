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
            object itemGachaGet = GetRandomItemGachaFromStorage();

            if (itemGachaGet != null) {

                string itemGachaToJson = JsonSerializer.Serialize(itemGachaGet, new JsonSerializerOptions());

                return Ok(itemGachaToJson);
            }

            return Ok("");
            
        }

        private object? GetRandomItemGachaFromStorage() {

            Dictionary<string, List<object>> itemsGacha = ItemsGachaStorage.GetInstance().GachaItemsDictionary;

            if (itemsGacha == null) return null;

            if (itemsGacha.TryGetValue(GetRandomItemGachaTypeFromStorage(), out List<object>? itemsGachaList)) {

                Random random = new Random();

                int indexGet = random.Next(0, itemsGachaList.Count);

                return itemsGachaList[indexGet];

            }

            return null;
        }

        private string? GetRandomItemGachaTypeFromStorage() {

            Dictionary<string, int[]> itemsGachaRateRange = ItemsGachaRateManager.GetInstance().ItemsGachaRateRange;

            Random random = new Random();

            int randomNumberInRateRange = random.Next(0, ItemsGachaRateManager.MAX_RANGE);

            if (itemsGachaRateRange == null) return null;

            foreach (string itemGachaType in itemsGachaRateRange.Keys) {

                if (itemsGachaRateRange.TryGetValue(itemGachaType, out int[]? itemGachaRateRange)) {

                    int startBorder = itemGachaRateRange[0];

                    int lastBorder = itemGachaRateRange[1];

                    if (randomNumberInRateRange >= startBorder && randomNumberInRateRange < lastBorder) {

                        return itemGachaType;
                    }
                }
                
            }

            return null;


        }


    }
}
