
using HustleFarmServer.Controllers.Model.UserDataForm;
using Newtonsoft.Json;

namespace HustleFarmServer.Controllers.Model
{
    public class UserAccountPlantsDataManager : UserAccountDataManager
    {
        public UserAccountPlantsDataManager() : base(KeysDataFB.EKeysDataFB.UserPlants)
        {
        }

        protected override void ConstructInitialData(Dictionary<string, object> initialData)
        {
            PlantData plant1 = new PlantData()
            {
                Id = "Crop",
                LifeSpan = "5 days",
                MaxHourForNextProvidingNutritions = 1,
                MaxHoursCanSurviveInBadStatus = 20,
                PointEachDay = 2,
                Type = "Common",
                TimeBorn = DateTime.Now.ToString(),
                LastTimeProvidingNutrition = DateTime.Now.ToString()
            };

            PlantData plant2 = new PlantData()
            {
                Id = "Crop",
                LifeSpan = "5 days",
                MaxHourForNextProvidingNutritions = 1,
                MaxHoursCanSurviveInBadStatus = 20,
                PointEachDay = 2,
                Type = "Common",
                LastTimeProvidingNutrition = DateTime.Now.ToString(),
                TimeBorn = DateTime.Now.ToString()
            };

            List<string> initialPlants = new List<string>() {
                JsonConvert.SerializeObject(plant1),
                JsonConvert.SerializeObject(plant2)
            };

            initialData.Add(UserPlants.PlantsField, initialPlants);
        }
    }
}
