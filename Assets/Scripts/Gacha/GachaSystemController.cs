using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GachaSystemController : ServerRequestController
{
    // Start is called before the first frame update
    private static readonly string ROUTER_PROVIDING_GACHA_ITEM = "GachaServer";

    [SerializeField] private TextMeshProUGUI result;

    [SerializeField] private GachaItemDisplaySystem itemsDisplaySystem;

    [SerializeField] private PutItemsGachaGetIntoUserBag putItemsGachaGetIntoUserBagSystem;
    void Start()
    {
        
    }

    public void GetRateFromServer(int time) {

        this.result.text = "";

        

        for (int i = 0; i < time; i++) {
            StartCoroutine(SendGetRequest(ROUTER_PROVIDING_GACHA_ITEM));
        }
   
    }

   

    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        string itemGachaId = request.downloadHandler.text;

        result.text += itemGachaId + "\n";

        itemsDisplaySystem.DisplayGachaItem(itemGachaId);

        if (!itemsDisplaySystem.gameObject.activeSelf)
        {
            itemsDisplaySystem.gameObject.SetActive(true);
        }

        if (putItemsGachaGetIntoUserBagSystem != null) { 
            putItemsGachaGetIntoUserBagSystem.PutItemsGachaIntoUserBag(itemGachaId);
        }
    }
}
