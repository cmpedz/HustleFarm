using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GachaSystemController : ServerRequestController
{
    // Start is called before the first frame update
    private static readonly string ROUTER_PROVIDING_GACHA_ITEM = "GachaServer";

    

    [SerializeField] private GachaItemDisplaySystem itemsDisplaySystem;

    [SerializeField] private PutItemsGachaGetIntoUserBag putItemsGachaGetIntoUserBagSystem;
    void Start()
    {
        
    }

    public void GetRateFromServer(int time) {

        

        for (int i = 0; i < time; i++) {
            StartCoroutine(SendGetRequest(ROUTER_PROVIDING_GACHA_ITEM));
        }
   
    }

   

    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {

        string plantId = request.downloadHandler.text;

        string plantIdToSeedId = "Seed " + plantId;


        itemsDisplaySystem.DisplayGachaItem(plantIdToSeedId);

        if (!itemsDisplaySystem.gameObject.activeSelf)
        {
            itemsDisplaySystem.gameObject.SetActive(true);
        }

        if (putItemsGachaGetIntoUserBagSystem != null) { 
            putItemsGachaGetIntoUserBagSystem.PutItemsGachaIntoUserBag(plantIdToSeedId);
        }
    }
}
