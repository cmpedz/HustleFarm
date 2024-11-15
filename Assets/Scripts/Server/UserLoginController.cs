using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class UserLoginController : ServerRequestController
{
    private static readonly string USER_LOGIN_ROUTER = "UserLogin";

    private static UserLoginController instance;
    public static UserLoginController Instance
    {
        get { return instance; }
    }

    [SerializeField] private RetrieveUserDataFromServer retrieveUserData;

    private void Start()
    {
        if (instance == null) {

            instance = this;

            string userWalletId = UserData.Instance.UserId;

            ConstructUserAccount(userWalletId);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        Debug.Log("check data retrieved from server : " + request.downloadHandler.text);
        if (retrieveUserData != null) {
            retrieveUserData.HandleDataRetrievedFromSever(request.downloadHandler.text);
        }
    }


    public void ConstructUserAccount(string userId)
    {
        string userIdToJson = "{ \"userId\""  + " : "  + "\"" + userId + "\"" + "}";
        Debug.Log("check user id json formed : " + userIdToJson);
        StartCoroutine(SendPostRequest(USER_LOGIN_ROUTER ,userIdToJson));
    }
}
