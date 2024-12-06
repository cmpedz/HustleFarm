using Assets.Scripts.ObjectDataManager;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleUserAnimalsData : HandleUserData<UserAnimals>
{

    private Dictionary<string, SerializedAnimalData> animalsUserHas = new Dictionary<string, SerializedAnimalData>();

    [SerializeField] private List<float> bonusGachaPointsRate = new List<float>();

    public void ChangeDataOfSpecifiedAnimal(string animalIndex, SerializedAnimalData newData)
    {
        animalsUserHas[animalIndex] = newData;  
    }

    public Dictionary<string, SerializedAnimalData> GetAnimalsUserHas()
    {
        return this.animalsUserHas;
    }

    public float GetBonusGachaPointRate() {

        float sumBonusGachaPointRate = 0;

        foreach(float bonusGachaPointRate in bonusGachaPointsRate)
        {
            sumBonusGachaPointRate += bonusGachaPointRate;  
        }

        return sumBonusGachaPointRate;
    }

    public SerializedAnimalData GetAnimalDataFromServer(string animalId)
    {
        if (animalsUserHas.ContainsKey(animalId)) { 

            return animalsUserHas[animalId];
        }

        return null;
    }

    public override void HandleDataEvent(UserAnimals data)
    {
        bonusGachaPointsRate.Clear();

        foreach (string animal in data.Animals)
        {
            SerializedAnimalData animalDataJsonStringToObject = JsonUtility.FromJson<SerializedAnimalData>(animal);

            animalsUserHas.Add(animalDataJsonStringToObject.NftId, animalDataJsonStringToObject);

            if (animalDataJsonStringToObject.PointGachaBonusRate != 0) {
                bonusGachaPointsRate.Add(animalDataJsonStringToObject.PointGachaBonusRate);
            }
        }

        Debug.Log("check animal data from server : " + JsonConvert.SerializeObject(animalsUserHas));
        
    }

   
}
