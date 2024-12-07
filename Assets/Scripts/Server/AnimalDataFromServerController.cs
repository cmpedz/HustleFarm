using Assets.Scripts.ObjectDataManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class AnimalDataFromServerController : ServerRequestController
{

    private readonly string ANIMAL_ROUTE = "AnimalsData";

    private Dictionary<string, SerializedAnimalData> initialAnimal = new Dictionary<string, SerializedAnimalData>();

    private static AnimalDataFromServerController instance;
    public static AnimalDataFromServerController Instance
    {
        get { 
            
            return instance; 
        }
    }

    protected new void Start()
    {

        base.Start();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            StartCoroutine(SendGetRequest(ANIMAL_ROUTE));
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public SerializedAnimalData GetSpecifiedAnimalData(string animalId)
    {
        if (this.initialAnimal.ContainsKey(animalId)) {
            return this.initialAnimal[animalId];
        }

        return null;
    }

    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {   
        string animalsDataInJson = request.downloadHandler.text;

        JObject animalsData = JObject.Parse(animalsDataInJson);

        foreach(var animalData in animalsData)
        {
            Debug.Log("check animal id : " + animalData.Key);

            Debug.Log("check animal data : " + animalData.Value.ToString());
            
            initialAnimal.Add(animalData.Key, JsonUtility.FromJson<SerializedAnimalData>(animalData.Value.ToString()));
        }

        Debug.Log("check intial animals data : " + JsonConvert.SerializeObject(initialAnimal));

    }
}