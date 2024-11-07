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
    
    private Dictionary<string, List<PlantsDataManager>> itemsGachaDictionary = new Dictionary<string, List<PlantsDataManager>>();
    void Start()
    {
        StartCoroutine(ExecuteGetRequestToServer(ROUTER_GACHA_ITEMS_STORAGE));
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        string result = request.downloadHandler.text;

        Debug.Log("check items gacha list in Json form : " + result);

        JObject itemsGachaJObject = JObject.Parse(result);


        foreach (var itemGachaType in itemsGachaJObject)
        {
            

            if (!itemsGachaDictionary.ContainsKey(itemGachaType.Key)) {
                itemsGachaDictionary.Add(itemGachaType.Key, new List<PlantsDataManager>());
            }
                
            foreach (var itemsGacha in itemGachaType.Value)
            {

                Debug.Log("check item gacha data to string : " + itemsGacha.ToString());

                PlantsDataManager plantData = JsonUtility.FromJson<PlantsDataManager>(itemsGacha.ToString());


                Debug.Log("check plant data after deserizalized : " + plantData);
            }
        }

       
    }
}
