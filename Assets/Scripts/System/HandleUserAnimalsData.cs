using Assets.Scripts.ObjectDataManager;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleUserAnimalsData : HandleUserData<UserAnimals>
{

    private Dictionary<string, SerializedAnimalData> animalsUserHas = new Dictionary<string, SerializedAnimalData>();

    public void ChangeDataOfSpecifiedAnimal(string animalIndex, SerializedAnimalData newData)
    {
        animalsUserHas[animalIndex] = newData;  
    }

    public Dictionary<string, SerializedAnimalData> GetAnimalsUserHas()
    {
        return this.animalsUserHas;
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
        foreach (string animal in data.Animals)
        {
            SerializedAnimalData jsonStringToObject = JsonUtility.FromJson<SerializedAnimalData>(animal);

            animalsUserHas.Add(jsonStringToObject.NftId, jsonStringToObject);
        }

        Debug.Log("check animal data from server : " + JsonConvert.SerializeObject(animalsUserHas));

    }

   
}
