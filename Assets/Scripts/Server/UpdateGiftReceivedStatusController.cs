using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateGiftReceivedStatusController : ServerRequestController
{
    private static readonly string GETTING_STATUS_ROUTER = "DailyGiftChangeingStatus";

    [SerializeField] private DailyGiftController dailyGiftController;
    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        
    }

    public void NotifyUserHasReceivedDailyGifts()
    {
        UserDailyGiftReceivedStatus newChange = new UserDailyGiftReceivedStatus()
        {
            UserId = InstanceUserGeneralInfors.Instance.UserId,
            IsReceived = true
        };

        Debug.Log(JsonUtility.ToJson(newChange));

        StartCoroutine(SendChangingStatusToServer(newChange));
    }

    private IEnumerator SendChangingStatusToServer(UserDailyGiftReceivedStatus newChange)
    {


        yield return StartCoroutine(SendPostRequest(GETTING_STATUS_ROUTER, JsonUtility.ToJson(newChange)));

        dailyGiftController.gameObject.SetActive(false);
    }
}
