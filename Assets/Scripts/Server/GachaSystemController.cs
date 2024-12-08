using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Thirdweb.Unity;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using static NBitcoin.Scripting.PubKeyProvider;

public class GachaSystemController : ServerRequestController
{
    // Start is called before the first frame update
    private static readonly string ROUTER_PROVIDING_GACHA_ITEM = "GachaServer";

    private const int COST_EACH_DRAW = 100;

    private const int GACHA_TICKET_NEEDED_EACH_DRAW = 1;

    private const int GACHA_POINT_GET = 1;

    [SerializeField] private GachaItemDisplaySystem itemsDisplaySystem;

    [SerializeField] private PutItemsGachaGetIntoUserBag putItemsGachaGetIntoUserBagSystem;

    [SerializeField] private CurrentUserPointController currentUserPointController;

    [SerializeField] private HandleUserAnimalsData handleUserAnimalsData;

    [SerializeField] private HandleUserInforsData userGachaTickets;

    protected new void Start()
    {
        base.Start();

        currentUserPointController = FindAnyObjectByType<CurrentUserPointController>();

        handleUserAnimalsData = FindAnyObjectByType<HandleUserAnimalsData>();

        userGachaTickets = FindAnyObjectByType<HandleUserInforsData>();
    }

    public async void GetItemFromServer(int time)
    {

        bool isCapableOfDrawing = await CheckCapableOfDrawing(time);

        Debug.Log("isCapableOfDrawing: " + isCapableOfDrawing);

        if (isCapableOfDrawing)
        {
            StartCoroutine(GetItemFromServerEnumrator(time));

            float sumGachaBonusRateGet = handleUserAnimalsData.GetBonusGachaPointRate();

            currentUserPointController.IncreaseCurrentUserPoint(InstanceUserGeneralInfors.Instance.UserId
                , GACHA_POINT_GET, sumGachaBonusRateGet);
        }
      



    }

    private async Task<bool> CheckCapableOfDrawing(int time)
    {


        int currentQuantitiesGachaTicketsHas = userGachaTickets.UserTicket;

        int quantitiesGachaTicketsNeeded = GACHA_TICKET_NEEDED_EACH_DRAW * time;

        if (currentQuantitiesGachaTicketsHas >= quantitiesGachaTicketsNeeded)
        {
            userGachaTickets.DescreaseUserTickets(quantitiesGachaTicketsNeeded);
            return true;

        }
        else
        {
            bool didPayForDraw = await UserWalletController.Instance.DepositToken(COST_EACH_DRAW * time);
            Debug.Log("lack of gacha tickets, pay to gacha");
            return didPayForDraw;
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

        foreach (IEnumerator task in tasksGetIbItem)
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

        if (putItemsGachaGetIntoUserBagSystem != null)
        {
            putItemsGachaGetIntoUserBagSystem.PutItemsGachaIntoUserBag(plantIdToSeedId);
        }
    }
}
