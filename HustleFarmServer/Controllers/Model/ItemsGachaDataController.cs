using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HustleFarmServer.Controllers.Model
{
    [ApiController]

    [Route("[controller]")]
    public class ItemsGachaDataController : ControllerBase
    {
        private ItemsGachaStorage itemsGachaStorage = ItemsGachaStorage.GetInstance();

        [HttpGet]
        public IActionResult GetItemsGachaData() {

            if (itemsGachaStorage != null && itemsGachaStorage.GachaItemsDictionary != null) { 

                Dictionary<string, List<object>> itemsGachaDictionary = itemsGachaStorage.GachaItemsDictionary;

                return Ok(JsonSerializer.Serialize(itemsGachaDictionary, new JsonSerializerOptions()));

            }

            return Ok("items gacha data is null");
        }

    }
}
