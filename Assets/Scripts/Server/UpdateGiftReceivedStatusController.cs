using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateGiftReceivedStatusController : ServerRequestController
{
    private static readonly string GETTING_STATUS_ROUTER = "DailyGiftChangingStatus";
    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        
    }

    public void NotifyUserHasReceivedDailyGifts()
    {
        UserDailyGiftReceivedStatus newChange = new UserDailyGiftReceivedStatus()
        {
            userId = InstanceUserGeneralInfors.Instance.UserId,
            isReceived = true
        };

        StartCoroutine(SendPostRequest(GETTING_STATUS_ROUTER, JsonUtility.ToJson(newChange)));
    }
}
