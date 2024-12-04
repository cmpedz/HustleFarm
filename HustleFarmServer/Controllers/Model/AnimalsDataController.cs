using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HustleFarmServer.Controllers.Model
{
    [ApiController]

    [Route("[controller]")]
    public class AnimalsDataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAnimalsData()
        { 

            string animalsDataToJson = AnimalDataManager.Instance.GetAnimalsData();

            return Ok(animalsDataToJson);
        }
    }
}
