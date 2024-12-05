using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ObjectDataManager
{
    [System.Serializable]
    public class SerializedAnimalData
    {
        public float MaxHoursForNextProvidedNutritions;
        public string NftId;
        public float PointBonusRate;
        public float PointGachaBonusRate;
        public string Type;
        public string Position = "";
        public string LastTimeProvidingNutrition;

        public void ConvertFromAnimalDataManager(AnimalDataManager animalDataManager)
        {
            MaxHoursForNextProvidedNutritions = animalDataManager.GetMaxHourForNextProviding();

            NftId = animalDataManager.Id;

            PointBonusRate = animalDataManager.PointBonusRate;

            PointGachaBonusRate = animalDataManager.PointGachaBonusRate;

            Type = animalDataManager.Type;

            Position = animalDataManager.Position.ToString();

            LastTimeProvidingNutrition = animalDataManager.GetLastTimeProvidingNutrition().ToString();


        }
    }
}
