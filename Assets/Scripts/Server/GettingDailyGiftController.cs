using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GettingDailyGiftController : ServerRequestController
{
    private static readonly string GETTING_STATUS_ROUTER = "DailyGiftGettingStatus";

    [SerializeField] private DailyGiftController dailyGiftController;

    private static GettingDailyGiftController instance;
    public static GettingDailyGiftController Instance
    {
        get { return instance; }
    }

    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {

        bool isReceivedDailyGift = true;

        try { 
            isReceivedDailyGift = bool.Parse(request.downloadHandler.text); 
        } 
        catch(Exception)
        {
            return;
        }
        

        if (!isReceivedDailyGift) {
            Debug.Log("user can receive daily gift");
            dailyGiftController.gameObject.SetActive(true);
        }
        else
        {
            dailyGiftController.gameObject.SetActive(false);
        }
    }

    protected new void Start()
    {
        base.Start();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("user need check daily gift receive status : " + InstanceUserGeneralInfors.Instance.UserId);

            string userIdToJson = "{ \"userId\"" + " : " + "\"" + InstanceUserGeneralInfors.Instance.UserId + "\"" + "}";

            StartCoroutine(SendPostRequest(GETTING_STATUS_ROUTER, userIdToJson));
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
