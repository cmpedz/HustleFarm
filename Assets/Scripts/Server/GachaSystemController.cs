using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Thirdweb.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using static NBitcoin.Scripting.PubKeyProvider;

public class GachaSystemController : ServerRequestController
{
    // Start is called before the first frame update
    private static readonly string ROUTER_PROVIDING_GACHA_ITEM = "GachaServer";

    private const int COST_EACH_DRAW = 100;

    [SerializeField] private GachaItemDisplaySystem itemsDisplaySystem;

    [SerializeField] private PutItemsGachaGetIntoUserBag putItemsGachaGetIntoUserBagSystem;
    void Start()
    {
        
    }

    public async void GetItemFromServer(int time) {


        bool didPayForDraw = await UserWalletController.Instance.DepositToken(COST_EACH_DRAW * time);

        if (didPayForDraw) {
            Debug.Log("transposit successfully");
            StartCoroutine(GetItemFromServerEnumrator(time));
        }
        
   
    }



    private IEnumerator GetItemFromServerEnumrator(int time)
    {

        List<IEnumerator> tasksGetIbItem = new List<IEnumerator>();

        int quantitiesTasksDone = 0;

        for (int i = 0; i < time; i++)
        {
            tasksGetIbItem.Add(SendGetRequest(ROUTER_PROVIDING_GACHA_ITEM));
        }

        foreach(IEnumerator task in tasksGetIbItem)
        {
            StartCoroutine(TrackTaskDone(task, () => { quantitiesTasksDone++; }));
        }

        yield return new WaitUntil(() => { return quantitiesTasksDone == time; });

        BagMenu.Instance.UpdateItemsChangeIntoServer();

    }

    private IEnumerator TrackTaskDone(IEnumerator taskExecuted, Action onComplete)
    {
            yield return StartCoroutine(taskExecuted);

            onComplete?.Invoke();
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
