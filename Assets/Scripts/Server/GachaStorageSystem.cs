using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GachaStorageSystem : ServerRequestController
{
    // Start is called before the first frame update
    private static readonly string ROUTER_GACHA_ITEMS_STORAGE = "ItemsGachaData";

    
    private Dictionary<string, SerializedPlantData> itemsGachaDictionary = new Dictionary<string, SerializedPlantData>();

    private static GachaStorageSystem instance;

    public static GachaStorageSystem Instance { get { return instance; } }

    void Start()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            StartCoroutine(SendGetRequest(ROUTER_GACHA_ITEMS_STORAGE));
        }
        else
        {
            Destroy(gameObject);
        }
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public SerializedPlantData RetrieveItemGachaData(string id)
    {
        if (!this.itemsGachaDictionary.ContainsKey(id)) return null;
        return this.itemsGachaDictionary[id];
    }


    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        string result = request.downloadHandler.text;

        Debug.Log("check items gacha list in Json form : " + result);

        JObject itemsGachaJObject = JObject.Parse(result);


        foreach (var itemGachaType in itemsGachaJObject)
        {


            foreach (var itemsGacha in itemGachaType.Value)
            {

                Debug.Log("check item gacha data to string : " + itemsGacha.ToString());

                SerializedPlantData plantData = JsonUtility.FromJson<SerializedPlantData>(itemsGacha.ToString());

                plantData.LastTimeProvidingNutrition = ObjectDataManager.DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS.ToString();

                

                string plantId = plantData.Id;

                if (!itemsGachaDictionary.ContainsKey(plantId))
                {

                    itemsGachaDictionary.Add(plantId, plantData);

                }

            }
                
                
        }

      

       
    }
}
