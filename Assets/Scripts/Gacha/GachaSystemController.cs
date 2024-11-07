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
    void Start()
    {
        
    }

    public void GetRateFromServer(int time) {

        this.result.text = "";

        

        for (int i = 0; i < time; i++) {
            StartCoroutine(ExecuteGetRequestToServer(ROUTER_PROVIDING_GACHA_ITEM));
        }
   
    }

   

    public override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        string resultText = request.downloadHandler.text;

        result.text += resultText + "\n";

        itemsDisplaySystem.DisplayGachaItem(resultText);

        if (!itemsDisplaySystem.gameObject.activeSelf)
        {
            itemsDisplaySystem.gameObject.SetActive(true);
        }
    }
}
